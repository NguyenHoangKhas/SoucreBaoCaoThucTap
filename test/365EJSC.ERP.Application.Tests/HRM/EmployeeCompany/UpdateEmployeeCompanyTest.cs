using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using Moq;
using System.Data;
using System.Linq.Expressions;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeCompany
{
    public class UpdateEmployeeCompanyTest
    {
        private readonly Mock<IEmployeeCompanySqlRepository> _mockRepo;
        private readonly Mock<ISqlUnitOfWork> _mockUnitOfWork;
        private readonly UpdateEmployeeCompanyHandler _handler;

        public UpdateEmployeeCompanyTest()
        {
            _mockRepo = new Mock<IEmployeeCompanySqlRepository>();
            _mockUnitOfWork = new Mock<ISqlUnitOfWork>();
            _handler = new UpdateEmployeeCompanyHandler(_mockRepo.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var request = new UpdateEmployeeCompanyRequest { Id = 1, EmployeeId = 2, CdId = 2 };
            var employeeCompany = new Entities.EmployeeCompany { Id = 1, EmployeeId = 1, CdId = 1 };
            _mockRepo.Setup(r => r.FindByIdAsync(1, true, It.IsAny<CancellationToken>())).ReturnsAsync(employeeCompany);
            _mockRepo.Setup(r => r.FindAll(It.IsAny<Expression<Func<Entities.EmployeeCompany, bool>>>(), It.IsAny<bool>()))
                     .Returns(EmployeeCompanyTestData.GetSample().AsQueryable());
            var mockTransaction = new Mock<IDbTransaction>();
            _mockUnitOfWork.Setup(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(mockTransaction.Object);
            _mockRepo.Setup(r => r.Update(employeeCompany));
            _mockUnitOfWork.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Handle_DuplicateRequest_ReturnsSuccessWithoutUpdating()
        {
            // Arrange
            var request = new UpdateEmployeeCompanyRequest { Id = 1, EmployeeId = 2, CdId = 2 };
            var employeeCompany = EmployeeCompanyTestData.GetSample().First();
            _mockRepo.Setup(r => r.FindByIdAsync(1, true, It.IsAny<CancellationToken>())).ReturnsAsync(employeeCompany);
            _mockRepo.Setup(r => r.FindAll(It.IsAny<Expression<Func<Entities.EmployeeCompany, bool>>>(), It.IsAny<bool>()))
                     .Returns(EmployeeCompanyTestData.GetSample().AsQueryable());

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            _mockRepo.Verify(r => r.Update(It.IsAny<Entities.EmployeeCompany>()), Times.Never());
        }

        [Fact]
        public async Task Handle_NotFound_ThrowsCustomException()
        {
            // Arrange
            var request = new UpdateEmployeeCompanyRequest { Id = 1, EmployeeId = 2, CdId = 2 };
            _mockRepo.Setup(r => r.FindByIdAsync(1, true, It.IsAny<CancellationToken>())).ReturnsAsync((Entities.EmployeeCompany)null);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<CustomException>(() => _handler.Handle(request, CancellationToken.None));
            Assert.Equal(MsgCode.ERR_EMPLOYEE_COMPANY_ID_NOT_FOUND, ex.MessageCode);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ThrowsCustomException()
        {
            // Arrange
            var request = new UpdateEmployeeCompanyRequest { Id = 0, EmployeeId = 2, CdId = 2 }; // Invalid Id

            // Act & Assert
            await Assert.ThrowsAsync<CustomException>(() => _handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_DatabaseError_RollsBackTransaction()
        {
            // Arrange
            var request = new UpdateEmployeeCompanyRequest { Id = 1, EmployeeId = 2, CdId = 2 };
            var employeeCompany = EmployeeCompanyTestData.GetSample().First();
            _mockRepo.Setup(r => r.FindByIdAsync(1, true, It.IsAny<CancellationToken>())).ReturnsAsync(employeeCompany);
            var mockTransaction = new Mock<IDbTransaction>();
            _mockUnitOfWork.Setup(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(mockTransaction.Object);
            _mockUnitOfWork.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>())).Throws(new Exception("DB Error"));
            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
            mockTransaction.Verify(t => t.Rollback(), Times.Once());
        }
    }
}
