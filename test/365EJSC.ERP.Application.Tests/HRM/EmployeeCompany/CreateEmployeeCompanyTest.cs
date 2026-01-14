using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using Moq;
using System.Data;
using System.Linq.Expressions;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeCompany
{
    public class CreateEmployeeCompanyTest
    {
        private readonly Mock<IEmployeeCompanySqlRepository> _mockRepo;
        private readonly Mock<ISqlUnitOfWork> _mockUnitOfWork;
        private readonly CreateEmployeeCompanyHandler _handler;

        public CreateEmployeeCompanyTest()
        {
            _mockRepo = new Mock<IEmployeeCompanySqlRepository>();
            _mockUnitOfWork = new Mock<ISqlUnitOfWork>();
            _handler = new CreateEmployeeCompanyHandler(_mockRepo.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var request = new CreateEmployeeCompanyRequest { EmployeeId = 1, CdId = 1 };
            _mockRepo.Setup(r => r.ValidateEmployeeCompany(1, 1)).Returns(Task.CompletedTask);
            var mockTransaction = new Mock<IDbTransaction>();
            _mockUnitOfWork.Setup(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(mockTransaction.Object);
            _mockRepo.Setup(r => r.Add(It.IsAny<Entities.EmployeeCompany>()));
            _mockUnitOfWork.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            mockTransaction.Verify(t => t.Commit(), Times.Once());
            mockTransaction.Verify(t => t.Rollback(), Times.Never());
        }

        [Fact]
        public async Task Handle_DuplicateRequest_ReturnsSuccessWithoutAdding()
        {
            // Arrange
            var request = new CreateEmployeeCompanyRequest { EmployeeId = 1, CdId = 1 };
            _mockRepo.Setup(r => r.FindAll(It.IsAny<Expression<Func<Entities.EmployeeCompany, bool>>>(), It.IsAny<bool>()))
                     .Returns(EmployeeCompanyTestData.GetSample().AsQueryable());

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            _mockRepo.Verify(r => r.Add(It.IsAny<Entities.EmployeeCompany>()), Times.Never());
            _mockUnitOfWork.Verify(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>()), Times.Never());
        }

        [Fact]
        public async Task Handle_InvalidRequest_ThrowsCustomException()
        {
            // Arrange
            var request = new CreateEmployeeCompanyRequest { EmployeeId = 0, CdId = 1 }; // Invalid EmployeeId

            // Act & Assert
            await Assert.ThrowsAsync<CustomException>(() => _handler.Handle(request, CancellationToken.None));
            _mockRepo.Verify(r => r.FindAll(It.IsAny<Expression<Func<Entities.EmployeeCompany, bool>>>(), It.IsAny<bool>()), Times.Never());
        }

        [Fact]
        public async Task Handle_DatabaseError_RollsBackTransaction()
        {
            // Arrange
            var request = new CreateEmployeeCompanyRequest { EmployeeId = 1, CdId = 1 };
            _mockRepo.Setup(r => r.FindAll(It.IsAny<Expression<Func<Entities.EmployeeCompany, bool>>>(), It.IsAny<bool>()))
                     .Returns(new Entities.EmployeeCompany[0].AsQueryable());
            _mockRepo.Setup(r => r.ValidateEmployeeCompany(1, 1)).Returns(Task.CompletedTask);
            var mockTransaction = new Mock<IDbTransaction>();
            _mockUnitOfWork.Setup(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(mockTransaction.Object);
            _mockRepo.Setup(r => r.Add(It.IsAny<Entities.EmployeeCompany>())).Throws(new Exception("DB Error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
            mockTransaction.Verify(t => t.Rollback(), Times.Once());
            mockTransaction.Verify(t => t.Commit(), Times.Never());
        }
    }
}
