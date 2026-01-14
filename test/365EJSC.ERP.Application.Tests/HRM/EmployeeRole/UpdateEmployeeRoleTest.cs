using _365EJSC.ERP.Application.Requests.HRM.EmployeeRole;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeRole;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using Moq;
using System.Data;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeRole
{
    public class UpdateEmployeeRoleTest
    {
        private readonly Mock<IEmployeeRoleSqlRepository> mockemployeeRoleSqlRepository;
        private readonly Mock<ISqlUnitOfWork> mockSqlUnitOfWork;
        private readonly UpdateEmployeeRoleHandler handler;

        public UpdateEmployeeRoleTest()
        {
            mockemployeeRoleSqlRepository = new Mock<IEmployeeRoleSqlRepository>();
            mockSqlUnitOfWork = new Mock<ISqlUnitOfWork>();
            handler = new UpdateEmployeeRoleHandler(mockSqlUnitOfWork.Object, mockemployeeRoleSqlRepository.Object);
        }
        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResult()
        {
            // Arrange
            var request = new UpdateEmployeeRoleRequest
            {
                Id = 1,
                EmpRoleName = "Updated Name"
            };
            var sample = new Domain.Entities.HRM.EmployeeRole();
            var mockTransaction = new Mock<IDbTransaction>();

            mockemployeeRoleSqlRepository
                .Setup(repo => repo.FindByIdAsync((int)request.Id, true, It.IsAny<CancellationToken>()))
                .ReturnsAsync(sample);

            mockSqlUnitOfWork
                .Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockTransaction.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            mockemployeeRoleSqlRepository.Verify(repo => repo.Update(sample), Times.Once);
            mockSqlUnitOfWork.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            mockTransaction.Verify(t => t.Commit(), Times.Once);
        }

        [Fact]
        public async Task Handle_SampleNotFound_ThrowsCustomException()
        {
            // Arrange
            var request = new UpdateEmployeeRoleRequest
            {
                Id = 1,
                EmpRoleName = "Updated Name"
            };
            mockemployeeRoleSqlRepository
                .Setup(repo => repo.FindByIdAsync((int)request.Id, true, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new CustomException
                {
                    MessageCode = MsgCode.ERR_EMPLOYEE_ROLE_ID_NOT_FOUND
                });

            // Act & Assert
            await Assert.ThrowsAsync<CustomException>(() => handler.Handle(request, CancellationToken.None));
            try
            {
                await handler.Handle(request, CancellationToken.None);
            }
            catch (CustomException e)
            {
                Assert.Equal(MsgCode.ERR_EMPLOYEE_ROLE_ID_NOT_FOUND, e.MessageCode);
            }
        }

        [Fact]
        public async Task Handle_ExceptionOccurs_TransactionRollsBack()
        {
            // Arrange
            var request = new UpdateEmployeeRoleRequest
            {
                Id = 1,
                EmpRoleName = "Updated Name"
            };
            var sample = new Domain.Entities.HRM.EmployeeRole();
            var mockTransaction = new Mock<IDbTransaction>();

            mockemployeeRoleSqlRepository
                .Setup(repo => repo.FindByIdAsync((int)request.Id, true, It.IsAny<CancellationToken>()))
                .ReturnsAsync(sample);

            mockSqlUnitOfWork
                .Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockTransaction.Object);

            mockemployeeRoleSqlRepository
                .Setup(repo => repo.Update(sample))
                .Throws(new Exception());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, CancellationToken.None));
            mockTransaction.Verify(t => t.Rollback(), Times.Once);
        }
    }
}
