using _365EJSC.ERP.Application.Requests.HRM.EmployeeRole;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeRole;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Entities.HRM;
using Moq;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeRole
{
    public class GetAllEmployeeRoleTest
    {
        private readonly Mock<IEmployeeRoleSqlRepository> mockemployeeRoleSqlRepository;
        private readonly GetAllEmployeeRoleHandler handler;

        public GetAllEmployeeRoleTest()
        {
            mockemployeeRoleSqlRepository = new Mock<IEmployeeRoleSqlRepository>();
            handler = new GetAllEmployeeRoleHandler(mockemployeeRoleSqlRepository.Object);
        }
        [Fact]
        public async Task Handle_Should_ReturnAllSamples()
        {
            // Arrange
            var samples = new List<Domain.Entities.HRM.EmployeeRole>
        {
            new() { Id = 1, EmpRoleName = "Sample 1", EmpRoleCode = "NV01" },
            new() { Id = 2, EmpRoleName = "Sample 2", EmpRoleCode = "NV02" }
        };
            mockemployeeRoleSqlRepository
                .Setup(repository => repository.FindAll(null, false))
                .Returns(samples.AsQueryable());

            var query = new GetAllEmployeeRoleRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data.Count());
            Assert.Contains(result.Data, s => s.Id == 1 && s.EmpRoleName == "Sample 1" && s.EmpRoleCode == "NV01");
            Assert.Contains(result.Data, s => s.Id == 2 && s.EmpRoleName == "Sample 2" && s.EmpRoleCode == "NV02");
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyList_When_NoSamples()
        {
            // Arrange
            mockemployeeRoleSqlRepository
                .Setup(r => r.FindAll(null, false))
                .Returns(new List<Domain.Entities.HRM.EmployeeRole>().AsQueryable());

            var query = new GetAllEmployeeRoleRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Data);
        }
    }
}
