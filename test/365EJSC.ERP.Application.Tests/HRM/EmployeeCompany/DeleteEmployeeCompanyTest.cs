using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using Moq;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;


namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeCompany
{
    public class DeleteEmployeeCompanyTest
    {
        private readonly Mock<IEmployeeCompanySqlRepository> _mockRepo;
        private readonly Mock<ISqlUnitOfWork> _mockUnitOfWork;
        private readonly DeleteEmployeeCompanyHandler _handler;

        public DeleteEmployeeCompanyTest()
        {
            _mockRepo = new Mock<IEmployeeCompanySqlRepository>();
            _mockUnitOfWork = new Mock<ISqlUnitOfWork>();
            _handler = new DeleteEmployeeCompanyHandler(_mockRepo.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var request = new DeleteEmployeeCompanyRequest { Id = 1 };
            var employeeCompany = EmployeeCompanyTestData.GetSample().First();
            _mockRepo.Setup(r => r.FindByIdAsync(1, true, It.IsAny<CancellationToken>())).ReturnsAsync(employeeCompany);
            var mockTransaction = new Mock<IDbTransaction>();
            _mockUnitOfWork.Setup(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(mockTransaction.Object);
            _mockRepo.Setup(r => r.Remove(employeeCompany));
            _mockUnitOfWork.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            _mockRepo.Verify(r => r.Remove(employeeCompany), Times.Once());
            mockTransaction.Verify(t => t.Commit(), Times.Once());
        }

        [Fact]
        public async Task Handle_NotFound_ThrowsCustomException()
        {
            // Arrange
            var request = new DeleteEmployeeCompanyRequest { Id = 1 };
            _mockRepo.Setup(r => r.FindByIdAsync(1, true, It.IsAny<CancellationToken>())).ReturnsAsync((Entities.EmployeeCompany)null);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<CustomException>(() => _handler.Handle(request, CancellationToken.None));
            Assert.Equal(MsgCode.ERR_EMPLOYEE_COMPANY_ID_NOT_FOUND, ex.MessageCode);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ThrowsCustomException()
        {
            // Arrange
            var request = new DeleteEmployeeCompanyRequest { Id = 0 }; // Invalid Id

            // Act & Assert
            await Assert.ThrowsAsync<CustomException>(() => _handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_DatabaseError_RollsBackTransaction()
        {
            // Arrange
            var request = new DeleteEmployeeCompanyRequest { Id = 1 };
            var employeeCompany = EmployeeCompanyTestData.GetSample().First();
            _mockRepo.Setup(r => r.FindByIdAsync(1, true, It.IsAny<CancellationToken>())).ReturnsAsync(employeeCompany);
            var mockTransaction = new Mock<IDbTransaction>();
            _mockUnitOfWork.Setup(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(mockTransaction.Object);
            _mockRepo.Setup(r => r.Remove(employeeCompany)).Throws(new Exception("DB Error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
            mockTransaction.Verify(t => t.Rollback(), Times.Once());
        }
    }
}
