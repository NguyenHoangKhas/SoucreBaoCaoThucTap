using _365EJSC.ERP.Application.Requests.HRM.DefineContractTypes;
using _365EJSC.ERP.Application.UserCases.HRM.DefineContractTypes;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using Moq;
using Entities = _365EJSC.ERP.Domain.Entities;

namespace _365EJSC.ERP.Application.Tests.HRM.DefineContractType
{
    public class GetAllContractTypeTest
    {
        private readonly Mock<IContractTypeSqlRepository> mockContractTypeSqlRepository;
        private readonly GetAllContractTypeHandler handler;

        public GetAllContractTypeTest()
        {
            mockContractTypeSqlRepository = new Mock<IContractTypeSqlRepository>();
            handler = new GetAllContractTypeHandler(mockContractTypeSqlRepository.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyList_When_NoContractTypes()
        {
            // Arrange
            mockContractTypeSqlRepository.Setup(r => r.FindAll(null, false)).Returns(new List<Entities.HRM.DefineContractTypes>().AsQueryable());
            var query = new GetAllContractTypeRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Data);
        }

        [Fact]
        public async Task Handle_Should_ReturnAllContractTypes()
        {
            // Arrange
            var defineContractTypes = new List<Entities.HRM.DefineContractTypes>
        {
            new() { Id = 1, ContractTypeCode = "D001", ContractTypeName = "HR" },
            new() { Id = 2, ContractTypeCode = "D002", ContractTypeName = "Finance" }
        };
            mockContractTypeSqlRepository.Setup(repository => repository.FindAll(null, false)).Returns(defineContractTypes.AsQueryable());
            var query = new GetAllContractTypeRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data.Count());
            Assert.Contains(result.Data, d => d.Id == 1 && d.ContractTypeName == "HR");
            Assert.Contains(result.Data, d => d.Id == 2 && d.ContractTypeName == "Finance");
        }
    }
}
