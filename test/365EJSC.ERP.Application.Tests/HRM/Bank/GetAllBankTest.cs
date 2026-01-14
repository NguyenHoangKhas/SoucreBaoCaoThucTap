using _365EJSC.ERP.Application.Requests.HRM.Bank;
using _365EJSC.ERP.Application.UserCases.HRM.Bank;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using EntitiesHRM= _365EJSC.ERP.Domain.Entities.HRM;
using Moq;

namespace _365EJSC.ERP.Application.Tests.HRM.Bank
{
    public class GetAllBankTest
    {
        private readonly Mock<IBankSqlRepository> mockBankSqlRepository;
        private readonly GetAllBankHandler handler;

        public GetAllBankTest()
        {
            mockBankSqlRepository = new Mock<IBankSqlRepository>();
            handler = new GetAllBankHandler(mockBankSqlRepository.Object);
        }
        [Fact]
        public async Task Handle_Should_ReturnAllBanks()
        {
            // Arrange
            var samples = new List<EntitiesHRM.Bank>
        {
            new() { Id = 1, BankName = "Sample 1" },
            new() { Id = 2, BankName = "Sample 2" }
        };
            mockBankSqlRepository
                .Setup(repository => repository.FindAll(null, false))
                .Returns(samples.AsQueryable());

            var query = new GetAllBankRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data.Count());
            Assert.Contains(result.Data, s => s.Id == 1 && s.BankName == "Sample 1");
            Assert.Contains(result.Data, s => s.Id == 2 && s.BankName == "Sample 2");
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyList_When_NoBanks()
        {
            // Arrange
            mockBankSqlRepository
                .Setup(r => r.FindAll(null, false))
                .Returns(new List<Domain.Entities.HRM.Bank>().AsQueryable());

            var query = new GetAllBankRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Data);
        }
    }
}
