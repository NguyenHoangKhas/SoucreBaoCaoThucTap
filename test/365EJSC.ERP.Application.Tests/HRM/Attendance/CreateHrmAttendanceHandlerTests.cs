using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Application.UserCases.HRM.Attendance;
using _365EJSC.ERP.Application.Validators.HRM.Attendance;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using Moq;
using System.Data;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace _365EJSC.ERP.Application.Tests.HRM.Attendance
{
    public class CreateHrmAttendanceHandlerTests
    {
        private readonly Mock<IHrmAttendanceSqlRepository> _mockRepo;
        private readonly Mock<ISqlUnitOfWork> _mockUow;
        private readonly CreateHrmAttendanceHandler _handler;

        private readonly CreateHrmAttendanceRequest _validRequest = new()
        {
            EmployeeId = 1,
            WorkDate = 20251121,
            CheckInTime = 1710604321,
            CheckOutTime = 1710624321,
            TotalWorkingMinutes = 480,
            AttendanceStatus = 1
        };

        public CreateHrmAttendanceHandlerTests()
        {
            _mockRepo = new Mock<IHrmAttendanceSqlRepository>();
            _mockUow = new Mock<ISqlUnitOfWork>();

            _handler = new CreateHrmAttendanceHandler(
                _mockRepo.Object,
                _mockUow.Object
            );
        }

        [Fact]
        public async Task Handle_ValidRequest_CommitsTransaction()
        {
            // Arrange
            var mockTransaction = new Mock<IDbTransaction>();
            _mockUow.Setup(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                    .ReturnsAsync(mockTransaction.Object);

            // Act
            var result = await _handler.Handle(_validRequest, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            _mockRepo.Verify(r => r.Add(It.IsAny<Domain.Entities.HRM.Attendance>()), Times.Once);
            mockTransaction.Verify(t => t.Commit(), Times.Once);
            mockTransaction.Verify(t => t.Rollback(), Times.Never);
        }

        [Fact]
        public void Handle_InvalidRequest_ThrowsValidationException()
        {
            // Arrange
            var invalidRequest = new CreateHrmAttendanceRequest(); // EmployeeId và WorkDate null

            var validator = new CreateHrmAttendanceValidator();

            // Act & Assert
            var ex = Assert.Throws<CustomException>(() => validator.ValidateAndThrow(invalidRequest));
            Assert.Equal(MsgCode.ERR_ATTENDANCE_INVALID, ex.MessageCode);
        }

        [Fact]
        public async Task Handle_SaveChangesThrowsException_RollsBackTransaction()
        {
            // Arrange
            var mockTransaction = new Mock<IDbTransaction>();
            _mockUow.Setup(u => u.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                    .ReturnsAsync(mockTransaction.Object);

            _mockUow.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
                    .ThrowsAsync(new Exception("DB error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(_validRequest, CancellationToken.None));

            mockTransaction.Verify(t => t.Rollback(), Times.Once);
            mockTransaction.Verify(t => t.Commit(), Times.Never);
        }
    }
}
