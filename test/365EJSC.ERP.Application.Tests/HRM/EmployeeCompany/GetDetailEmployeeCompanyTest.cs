using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using Moq;
using System.Linq.Expressions;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;


namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeCompany
{
    public class GetDetailEmployeeCompanyTest
    {
        private readonly Mock<IEmployeeCompanySqlRepository> _mockRepo;
        private readonly GetDetailEmployeeCompanyHandler _handler;

        public GetDetailEmployeeCompanyTest()
        {
            _mockRepo = new Mock<IEmployeeCompanySqlRepository>();
            _handler = new GetDetailEmployeeCompanyHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsEmployeeCompany()
        {
            // Arrange
            var request = new GetDetailEmployeeCompanyRequest { Id = 1 };
            var employeeCompany = EmployeeCompanyTestData.GetSample().First();
            _mockRepo.Setup(r => r.FindAll(It.IsAny<Expression<Func<Entities.EmployeeCompany, bool>>>(), It.IsAny<bool>()))
                     .Returns(new[] { employeeCompany }.AsQueryable());

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(employeeCompany, result.Data);
        }

        [Fact]
        public async Task Handle_NotFound_ThrowsCustomException()
        {
            // Arrange
            var request = new GetDetailEmployeeCompanyRequest { Id = 1 };
            _mockRepo.Setup(r => r.FindAll(It.IsAny<Expression<Func<Entities.EmployeeCompany, bool>>>(), It.IsAny<bool>()))
                     .Returns(new Entities.EmployeeCompany[0].AsQueryable());

            // Act & Assert
            var ex = await Assert.ThrowsAsync<CustomException>(() => _handler.Handle(request, CancellationToken.None));
            Assert.Equal(MsgCode.ERR_EMPLOYEE_COMPANY_ID_NOT_FOUND, ex.MessageCode);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ThrowsCustomException()
        {
            // Arrange
            var request = new GetDetailEmployeeCompanyRequest { Id = 0 }; // Invalid Id

            // Act & Assert
            await Assert.ThrowsAsync<CustomException>(() => _handler.Handle(request, CancellationToken.None));
        }
    }
}
