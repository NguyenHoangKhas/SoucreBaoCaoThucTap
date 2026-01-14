using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.UserCases.HRM.Employee;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using Moq;

namespace _365EJSC.ERP.Application.Tests.HRM.Employee
{
    /// <summary>
    /// Test class for deleting Employee entities.
    /// </summary>
    public class DeleteEmployeeTest
    {
        private readonly Mock<IEmployeeSqlRepository> mockEmployeeSqlRepository;
        private readonly Mock<ISqlUnitOfWork> mockSqlUnitOfWork;
        private readonly DeleteEmployeeHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEmployeeTest"/> class.
        /// </summary>
        public DeleteEmployeeTest()
        {
            mockEmployeeSqlRepository = new Mock<IEmployeeSqlRepository>();
            mockSqlUnitOfWork = new Mock<ISqlUnitOfWork>();
            handler = new DeleteEmployeeHandler(mockEmployeeSqlRepository.Object, mockSqlUnitOfWork.Object);
        }



        [Fact]
        public async Task Handle_EmployeeNotFound_ThrowsCustomException()
        {
            // Arrange
            var request = new DeleteEmployeeRequest { Id = 1 };

            mockEmployeeSqlRepository
                .Setup(repo => repo.FindByIdAsync((int)request.Id, true, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new CustomException
                {
                    MessageCode = MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND
                });

            // Act & Assert
            await Assert.ThrowsAsync<CustomException>(() => handler.Handle(request, CancellationToken.None));
            try
            {
                await handler.Handle(request, CancellationToken.None);
            }
            catch (CustomException e)
            {
                Assert.Equal(MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND, e.MessageCode);
            }
        }
    }
}
