using _365EJSC.ERP.Application.Requests.HRM.AttendanceHis;
using _365EJSC.ERP.Application.UserCases.HRM.AttendanceHis;
using _365EJSC.ERP.Application.Validators.HRM.AttendanceHis;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using Moq;
using System.Data;
using Xunit;

namespace _365EJSC.ERP.Application.Tests.HRM.AttendanceHis
{
    public class CreateHrmAttendanceHisTest
    {
        private readonly Mock<IHrmAttendanceHisSqlRepository> mockRepository;
        private readonly Mock<ISqlUnitOfWork> mockUnitOfWork;
        private readonly CreateHrmAttendanceHisHandler handler;

        private readonly CreateHrmAttendanceHisRequest validRequest = new()
        {
            AttendanceId = 1,
            CheckInTime = DateTimeOffset.FromUnixTimeSeconds(1710604321).UtcDateTime,
            CheckOutTime = DateTimeOffset.FromUnixTimeSeconds(1710618721).UtcDateTime,
            NumLate = 0,
            NumEarlyLeave = 0,
            WorkingMinutes = 480,
            IsActived = 1
        };

        public CreateHrmAttendanceHisTest()
        {
            mockRepository = new Mock<IHrmAttendanceHisSqlRepository>();
            mockUnitOfWork = new Mock<ISqlUnitOfWork>();
            handler = new CreateHrmAttendanceHisHandler(mockRepository.Object, mockUnitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var mockTransaction = new Mock<IDbTransaction>();
            mockUnitOfWork.Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                          .ReturnsAsync(mockTransaction.Object);

            // Act
            var result = await handler.Handle(validRequest, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data); // Entity được trả về
            mockRepository.Verify(r => r.Add(It.IsAny<Domain.Entities.HRM.AttendanceHis>()), Times.Once);
            mockUnitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            mockTransaction.Verify(t => t.Commit(), Times.Once);
            mockTransaction.Verify(t => t.Rollback(), Times.Never);
        }

       


        [Fact]
        public async Task Handle_RepositoryThrowsException_TransactionRollsBack()
        {
            // Arrange
            var mockTransaction = new Mock<IDbTransaction>();
            mockUnitOfWork.Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                          .ReturnsAsync(mockTransaction.Object);

            mockUnitOfWork.Setup(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()))
                          .ThrowsAsync(new Exception("DB error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(validRequest, CancellationToken.None));
            mockTransaction.Verify(t => t.Rollback(), Times.Once);
        }
    }
}
