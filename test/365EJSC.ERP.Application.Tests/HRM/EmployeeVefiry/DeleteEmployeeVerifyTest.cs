using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using Moq;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeVerifyVefiry
{
    /// <summary>
    /// Test class for deleting EmployeeVerify entities.
    /// </summary>
    public class DeleteEmployeeVerifyTest
    {
        private readonly Mock<IEmployeeVerifySqlRepository> mockEmployeeVerifySqlRepository;
        private readonly Mock<ISqlUnitOfWork> mockSqlUnitOfWork;
        private readonly DeleteEmployeeVerifyHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEmployeeVerifyTest"/> class.
        /// </summary>
        public DeleteEmployeeVerifyTest()
        {
            mockEmployeeVerifySqlRepository = new Mock<IEmployeeVerifySqlRepository>();
            mockSqlUnitOfWork = new Mock<ISqlUnitOfWork>();
            handler = new DeleteEmployeeVerifyHandler(mockEmployeeVerifySqlRepository.Object, mockSqlUnitOfWork.Object);
        }



        [Fact]
        public async Task Handle_EmployeeVerifyNotFound_ThrowsCustomException()
        {
            // Arrange
            var request = new DeleteEmployeeVerifyRequest { Id = 1 };

            mockEmployeeVerifySqlRepository
                .Setup(repo => repo.FindByIdAsync((int)request.Id, true, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new CustomException
                {
                    MessageCode = MsgCode.ERR_EMPLOYEE_VERIFY_ID_NOT_FOUND
                });

            // Act & Assert
            await Assert.ThrowsAsync<CustomException>(() => handler.Handle(request, CancellationToken.None));
            try
            {
                await handler.Handle(request, CancellationToken.None);
            }
            catch (CustomException e)
            {
                Assert.Equal(MsgCode.ERR_EMPLOYEE_VERIFY_ID_NOT_FOUND, e.MessageCode);
            }
        }
    }
}
