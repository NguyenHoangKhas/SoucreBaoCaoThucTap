using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.UserCases.HRM.Employee;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using Moq;
using System.Linq.Expressions;

namespace _365EJSC.ERP.Application.Tests.HRM.Employee
{
    /// <summary>
    /// Test class for GetEmployeeByIdQueryHandler.
    /// </summary>
    public class GetDetailEmployeeTest
    {
        private readonly Mock<IEmployeeSqlRepository> mockEmployeeSqlRepository;
        private readonly Mock<IFileService> mockFileService;
        private readonly GetDetailEmployeeHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDetailEmployeeTest"/> class.
        /// </summary>
        public GetDetailEmployeeTest()
        {
            mockEmployeeSqlRepository = new Mock<IEmployeeSqlRepository>();
            mockFileService = new Mock<IFileService>();
            handler = new GetDetailEmployeeHandler(mockEmployeeSqlRepository.Object, mockFileService.Object);
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessful()
        {
            mockEmployeeSqlRepository.Setup(r => r.FindAll(It.IsAny<Expression<Func<Domain.Entities.HRM.Employee, bool>>>(), It.IsAny<bool>()))
                .Returns(EmployeeCatalogTestData.GetSample().AsQueryable());
            var query = new GetDetailEmployeeRequest { Id = 1 };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.True(result.Data != null);
        }

        [Fact]
        public async Task Handle_Should_ThrowException_When_Employee_NotFound()
        {
            // Arrange
            var query = new GetDetailEmployeeRequest { Id = 99 };

            try
            {
                await handler.Handle(query, CancellationToken.None);
            }
            catch (CustomException e)
            {
                Assert.Equal(MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND, e.MessageCode);
            }
        }

        [Fact]
        public Task Handle_Should_ThrowException_When_Request_Invalid()
        {
            // Arrange
            var request = new GetDetailEmployeeRequest
            {
                // Set invalid properties of GetDetailEmployeeQuery here
            };

            var validator = new GetDetailEmployeeValidator();
            Assert.Throws<CustomException>(() => validator.ValidateAndThrow(request));

            // Act & Assert
            try
            {
                validator.ValidateAndThrow(request);
            }
            catch (CustomException e)
            {
                Assert.Equal(MsgCode.ERR_EMPLOYEE_INVALID, e.MessageCode);
            }
            return Task.CompletedTask;
        }
    }
}
