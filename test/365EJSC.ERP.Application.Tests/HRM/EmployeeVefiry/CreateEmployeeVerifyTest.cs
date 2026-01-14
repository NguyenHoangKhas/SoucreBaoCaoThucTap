//using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
//using _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify;
//using _365EJSC.ERP.Application.Validators.HRM.EmployeeVerify;
//using _365EJSC.ERP.Contract.Enumerations;
//using _365EJSC.ERP.Contract.Exceptions;
//using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
//using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
//using Moq;
//using System.Data;

//namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeVerifyVefiry
//{
//    /// <summary>
//    /// Test class for creating EmployeeVerify entities.
//    /// </summary>
//    public class CreateEmployeeVerifyTest
//    {
//        private readonly Mock<IEmployeeVerifySqlRepository> mockEmployeeVerifySqlRepository;
//        private readonly Mock<IEmployeeSqlRepository> mockEmployeeSqlRepository;
//        private readonly Mock<ISqlUnitOfWork> mockSqlUnitOfWork;
//        /// <summary>
//        private readonly CreateEmployeeVerifyHandler handler;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="CreateEmployeeVerifyTest"/> class.
//        /// </summary>
//        public CreateEmployeeVerifyTest()
//        {
//            mockEmployeeVerifySqlRepository = new Mock<IEmployeeVerifySqlRepository>();
//            mockEmployeeSqlRepository = new Mock<IEmployeeSqlRepository>();
//            mockSqlUnitOfWork = new Mock<ISqlUnitOfWork>();
//            handler = new CreateEmployeeVerifyHandler(
//                                                mockEmployeeVerifySqlRepository.Object,
//                                                mockSqlUnitOfWork.Object,
//                                                mockEmployeeSqlRepository.Object
//                                            );

//        }

//        [Fact]
//        public Task Handle_InvalidRequest_ThrowsValidationException()
//        {
//            // Arrange
//            var request = new CreateEmployeeVerifyRequest
//            {
//            };

//            var validator = new CreateEmployeeVerifyValidator();
//            Assert.Throws<CustomException>(() => validator.ValidateAndThrow(request));

//            // Act & Assert
//            try
//            {
//                validator.ValidateAndThrow(request);
//            }
//            catch (CustomException e)
//            {
//                Assert.Equal(MsgCode.ERR_EMPLOYEE_VERIFY_INVALID, e.MessageCode);
//            }
//            return Task.CompletedTask;
//        }

//        [Fact]
//        public async Task Handle_RepositoryThrowsException_TransactionRollsBack()
//        {
//            // Arrange
//            var request = new CreateEmployeeVerifyRequest
//            {
//                EmployeeId = 1001,
//                VerImage = "verification_1001.png",
//                UserIdVerify = 2002,
//                VerCreatedDate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
//                IsActived = 1
//            };

//            var mockTransaction = new Mock<IDbTransaction>();
//            mockSqlUnitOfWork
//              .Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
//              .ReturnsAsync(mockTransaction.Object);


//            // Act & Assert
//            mockTransaction.Verify(t => t.Commit(), Times.Never);
//        }
//    }
//}
