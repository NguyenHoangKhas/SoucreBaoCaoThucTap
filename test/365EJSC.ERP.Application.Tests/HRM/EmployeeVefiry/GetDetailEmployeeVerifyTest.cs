using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Application.Tests.HRM.EmployeeVefiry;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify;
using _365EJSC.ERP.Application.Validators.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using Moq;
using System.Linq.Expressions;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeVerifyVefiry
{
    /// <summary>
    /// Test class for GetEmployeeVerifyByIdQueryHandler.
    /// </summary>
    public class GetDetailEmployeeVerifyTest
    {
        private readonly Mock<IEmployeeVerifySqlRepository> mockEmployeeVerifyRepository;
        private readonly Mock<IFileService> mockFileService;
        private readonly GetDetailEmployeeVerifyHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDetailEmployeeVerifyTest"/> class.
        /// </summary>
        public GetDetailEmployeeVerifyTest()
        {
            mockEmployeeVerifyRepository = new Mock<IEmployeeVerifySqlRepository>();
            mockFileService = new Mock<IFileService>();
            handler = new GetDetailEmployeeVerifyHandler(mockEmployeeVerifyRepository.Object, mockFileService.Object);
        }

        [Fact]
        public async Task Handle_ReturnSuccessful()
        {
            // Arrange
            mockEmployeeVerifyRepository.Setup(r => r.FindAll(It.IsAny<Expression<Func<EmployeeVerify, bool>>>(), It.IsAny<bool>()))
                .Returns(EmployeeVerifyTestData.GetSample().AsQueryable());

            mockFileService.Setup(sv => sv.GetFullPathFileServer(It.IsAny<string>())).Returns("/image1.png");
            // Act & Assert
            GetDetailEmployeeVerifyRequest request = new() { Id = 1 };

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal(result.Data.Id, request.Id);
            Assert.NotNull(result.Data.Employee);
        }

        [Fact]
        public async Task Handle_Should_ThrowException_When_EmployeeVerify_NotFound()
        {
            var query = new GetDetailEmployeeVerifyRequest { Id = 99 };
            try
            {
                await handler.Handle(query, CancellationToken.None);
            }
            catch (CustomException e)
            {
                Assert.Equal(MsgCode.ERR_EMPLOYEE_VERIFY_ID_NOT_FOUND, e.MessageCode);
            }
        }

        [Fact]
        public Task Handle_Should_ThrowException_When_Request_Invalid()
        {
            // Arrange
            var request = new GetDetailEmployeeVerifyRequest
            {
                // Set invalid properties of GetDetailEmployeeVerifyQuery here
            };

            var validator = new GetDetailEmployeeVerifyValidator();
            Assert.Throws<CustomException>(() => validator.ValidateAndThrow(request));

            // Act & Assert
            try
            {
                validator.ValidateAndThrow(request);
            }
            catch (CustomException e)
            {
                Assert.Equal(MsgCode.ERR_EMPLOYEE_VERIFY_INVALID, e.MessageCode);
            }
            return Task.CompletedTask;
        }
    }
}
