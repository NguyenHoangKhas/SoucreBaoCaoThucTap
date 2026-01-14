//using _365EJSC.ERP.Application.Requests.HRM.Employee;
//using _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify;
//using _365EJSC.ERP.Contract.Exceptions;
//using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
//using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
//using Moq;
//using Entities = _365EJSC.ERP.Domain.Entities.HRM;
//using System.Data;
//using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;

//namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeVefiry
//{
//    public class UpdateEmployeeVerifyTest
//    {
//        private readonly Mock<IEmployeeVerifySqlRepository> mockEmployeeVerifySqlRepository;
//        private readonly Mock<IEmployeeSqlRepository> mockEmployeeSqlRepository;
//        private readonly Mock<ISqlUnitOfWork> mockSqlUnitOfWork;
//        /// <summary>
//        private readonly UpdateEmployeeVerifyHandler handler;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="CreateEmployeeVerifyTest"/> class.
//        /// </summary>
//        public UpdateEmployeeVerifyTest()
//        {
//            mockEmployeeVerifySqlRepository = new Mock<IEmployeeVerifySqlRepository>();
//            mockEmployeeSqlRepository = new Mock<IEmployeeSqlRepository>();
//            mockSqlUnitOfWork = new Mock<ISqlUnitOfWork>();
//            handler = new UpdateEmployeeVerifyHandler(
//                                                mockEmployeeVerifySqlRepository.Object,
//                                                mockSqlUnitOfWork.Object,
//                                                mockEmployeeSqlRepository.Object
//                                            );

//        }

//        [Fact]
//        public async Task Handle_RepositoryThrowsException_TransactionRollsBack()
//        {
//            // Arrange
//            var request = new UpdateEmployeeVerifyRequest
//            {
//                EmployeeId = 1001,
//                VerImage = "verification_1001.png",
//                UserIdVerify = 2002,
//                VerCreatedDate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
//                IsActived = 1
//            };

//            var mockTransaction = new Mock<IDbTransaction>();
//            mockSqlUnitOfWork.Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
//                             .ReturnsAsync(mockTransaction.Object);

//            mockEmployeeVerifySqlRepository.Setup(repo => repo.FindByIdAsync(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
//                                  .ReturnsAsync(new Entities.EmployeeVerify { Id = 1 }); // Simulate finding the district

//            // Act & Assert
//            await Assert.ThrowsAsync<CustomException>(() => handler.Handle(request, CancellationToken.None));  // Expecting CustomException
//        }
//    }
//}
