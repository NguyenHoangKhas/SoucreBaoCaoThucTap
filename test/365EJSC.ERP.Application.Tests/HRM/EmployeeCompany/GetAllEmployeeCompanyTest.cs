using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using Moq;
using System.Linq.Expressions;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeCompany
{
    public class GetAllEmployeeCompanyTest
    {
        private readonly Mock<IEmployeeCompanySqlRepository> _mockRepo;
        private readonly GetAllEmployeeCompanyHandler _handler;

        public GetAllEmployeeCompanyTest()
        {
            _mockRepo = new Mock<IEmployeeCompanySqlRepository>();
            _handler = new GetAllEmployeeCompanyHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ReturnsAllEmployeeCompanies()
        {
            // Arrange
            var employeeCompanies = EmployeeCompanyTestData.GetSample().AsQueryable();
            _mockRepo.Setup(r => r.FindAll(It.IsAny<Expression<Func<Entities.EmployeeCompany, bool>>>(), It.IsAny<bool>())).Returns(employeeCompanies);
            var request = new GetAllEmployeeCompanyRequest();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(4, result.Data.Count());
        }
    }
}
