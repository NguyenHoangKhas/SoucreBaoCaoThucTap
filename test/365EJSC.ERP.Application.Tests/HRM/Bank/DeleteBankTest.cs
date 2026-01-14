using _365EJSC.ERP.Application.Requests.HRM.Bank;
using _365EJSC.ERP.Application.UserCases.HRM.Bank;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using Moq;
using System.Data;
using System.Linq.Expressions;

namespace _365EJSC.ERP.Application.Tests.HRM.Bank
{
    public class DeleteBankTest
    {
        private readonly Mock<IBankSqlRepository> mockBankSqlRepository;
        //private readonly Mock<ICustomerCatalogSqlRepository> mockCustomerCatalogSqlRepository;
        private readonly Mock<ISqlUnitOfWork> mockSqlUnitOfWork;
        private readonly DeleteBankHandler handler;
        //private readonly Mock<ISupplierCatalogSqlRepository> mocksupplierCatalogSqlRepository;
        //private readonly Mock<IWhCatalogSqlRepository> mockwhCatalogSqlRepository;
        //private readonly Mock<ICompanySqlRepository> mockcompanySqlRepository;

        public DeleteBankTest()
        {
            mockBankSqlRepository = new Mock<IBankSqlRepository>();
            //mockCustomerCatalogSqlRepository = new Mock<ICustomerCatalogSqlRepository>();
            mockSqlUnitOfWork = new Mock<ISqlUnitOfWork>();
            handler = new DeleteBankHandler(mockBankSqlRepository.Object, 
                mockSqlUnitOfWork.Object//, 
                //mockCustomerCatalogSqlRepository.Object
                //mocksupplierCatalogSqlRepository.Object,
                //mockwhCatalogSqlRepository.Object,
                //mockcompanySqlRepository.Object
                );
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResult()
        {
            // Arrange
            var request = new DeleteBankRequest { Id = 1 };
            var sample = new Domain.Entities.HRM.Bank();
            var mockTransaction = new Mock<IDbTransaction>();

            //mockCustomerCatalogSqlRepository
            //    .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<CustomerCatalog, bool>>>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(false); // Bank không đang được sử dụng

            mockBankSqlRepository
                .Setup(repo => repo.FindByIdAsync(request.Id ?? 0, true, It.IsAny<CancellationToken>()))
                .ReturnsAsync(sample);

            mockSqlUnitOfWork
                .Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockTransaction.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            mockBankSqlRepository.Verify(repo => repo.Remove(sample), Times.Once);
            mockSqlUnitOfWork.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            mockTransaction.Verify(t => t.Commit(), Times.Once);
            mockTransaction.Verify(t => t.Rollback(), Times.Never);
        }

        [Fact]
        public async Task Handle_SampleNotFound_ThrowsCustomException()
        {
            // Arrange
            var request = new DeleteBankRequest { Id = 1 };

            //mockCustomerCatalogSqlRepository
            //    .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<CustomerCatalog, bool>>>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(false); // Không bị sử dụng

            mockBankSqlRepository
                .Setup<Task<Domain.Entities.HRM.Bank>>(repo => repo.FindByIdAsync(request.Id ?? 0, true, It.IsAny<CancellationToken>()))
                .ReturnsAsync<IBankSqlRepository, Domain.Entities.HRM.Bank>((Domain.Entities.HRM.Bank?)null); // Không tìm thấy bank

            // Act & Assert
            var exception = await Assert.ThrowsAsync<CustomException>(() => handler.Handle(request, CancellationToken.None));
            Assert.Equal(MsgCode.ERR_BANK_ID_NOT_FOUND, exception.MessageCode);

            mockSqlUnitOfWork.Verify(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()), Times.Never);
            mockSqlUnitOfWork.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_BankInUse_ThrowsCustomException()
        {
            // Arrange
            var request = new DeleteBankRequest { Id = 1 };

            //mockCustomerCatalogSqlRepository
            //    .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<CustomerCatalog, bool>>>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(true); // Bank đang được sử dụng

            // Act & Assert
            var exception = await Assert.ThrowsAsync<CustomException>(() => handler.Handle(request, CancellationToken.None));
            Assert.Equal(MsgCode.ERR_BANK_IN_USE, exception.MessageCode);

            mockBankSqlRepository.Verify(repo => repo.FindByIdAsync(It.IsAny<int>(), true, It.IsAny<CancellationToken>()), Times.Never);
            mockSqlUnitOfWork.Verify(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ExceptionOccurs_TransactionRollsBack()
        {
            // Arrange
            var request = new DeleteBankRequest { Id = 1 };
            var sample = new Domain.Entities.HRM.Bank();
            var mockTransaction = new Mock<IDbTransaction>();

            //mockCustomerCatalogSqlRepository
            //    .Setup(repo => repo.IsExistAsync(It.IsAny<Expression<Func<CustomerCatalog, bool>>>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(false);

            mockBankSqlRepository
                .Setup(repo => repo.FindByIdAsync(request.Id ?? 0, true, It.IsAny<CancellationToken>()))
                .ReturnsAsync(sample);

            mockSqlUnitOfWork
                .Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockTransaction.Object);

            mockBankSqlRepository
                .Setup(repo => repo.Remove(sample))
                .Throws(new Exception()); // Xảy ra lỗi khi xóa bank

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, CancellationToken.None));

            mockTransaction.Verify(t => t.Rollback(), Times.Once);
            mockTransaction.Verify(t => t.Commit(), Times.Never);
        }
    }
}
