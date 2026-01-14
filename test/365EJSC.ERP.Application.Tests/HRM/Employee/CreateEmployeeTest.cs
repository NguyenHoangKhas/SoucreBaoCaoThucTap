using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.UserCases.HRM.Employee;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.DTOs;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using Moq;
using System.Data;

namespace _365EJSC.ERP.Application.Tests.HRM.Employee
{
    /// <summary>
    /// Test class for creating Employee entities.
    /// </summary>
    public class CreateEmployeeTest
    {
        private readonly Mock<IEmployeeSqlRepository> mockEmployeeSqlRepository;
        private readonly Mock<ISqlUnitOfWork> mockSqlUnitOfWork;
        private readonly Mock<IFileService> mockFileService;
        private readonly Mock<IPasswordHasher> mockPasswordHasher;
        private readonly CreateEmployeeHandler handler;
        private readonly CreateEmployeeRequest validRequest = new ()
        {
            EmpCitizenIdentity = "123456789",
            EmpTaxCode = "987654321",
            EmpCode = "EMP001",
            EmpFirstName = "John",
            EmpLastName = "Doe",
            EmpGender = false,
            EmpBirthday = 1710604321,
            EmpPlaceOfBirth = 1,
            EmpImageBase64 = "profile.jpg",
            EmpTel = "0123456789",
            EmpEmail = "johndoe@example.com",
            EmpEducationLevel = "Lv 10000",
            EmpJoinedDate = 1710604321,
            DegreeId = 2,
            TraMajId = 3,
            EmpAccountNumber = "112233445566",
            BankId = 4,
            NationId = 1,
            ReligionId = 2,
            MaritalId = 1,
            EmpRoleId = 5,
            CountryId = "VN",
            EmpPlaceOfResidenceAddress = "123 Main Street, City, Country",
            EmpPlaceOfResidenceWardId = 6,
            IsActived = 1,
            Password = "123",
            CompanyId = 1
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmployeeTest"/> class.
        /// </summary>
        public CreateEmployeeTest()
        {
            mockEmployeeSqlRepository = new Mock<IEmployeeSqlRepository>();
            mockFileService = new Mock<IFileService>();
            mockSqlUnitOfWork = new Mock<ISqlUnitOfWork>();
            mockPasswordHasher = new Mock<IPasswordHasher>();
            handler = new CreateEmployeeHandler(mockEmployeeSqlRepository.Object, mockSqlUnitOfWork.Object, mockFileService.Object, mockPasswordHasher.Object);
        }

        [Fact]
        public async Task Handle_ReturnSuccess()
        {
            var mockTransaction = new Mock<IDbTransaction>();

            mockSqlUnitOfWork.Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockTransaction.Object);

            mockFileService.Setup(x => x.UploadFileAsync(It.IsAny<UploadFileRequest>())).ReturnsAsync("/image/testImage.png");

            var result = await handler.Handle(validRequest, CancellationToken.None);

            Assert.True(result.IsSuccess);
            mockTransaction.Verify(t => t.Commit(), Times.Once);
            mockTransaction.Verify(t => t.Rollback(), Times.Never);
        }

        [Fact]
        public Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Arrange
            var request = new CreateEmployeeRequest
            {
            };

            var validator = new CreateEmployeeValidator();
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

        [Fact]
        public async Task Handle_RepositoryThrowsException_TransactionRollsBack()
        {
            // Arrange
            var mockTransaction = new Mock<IDbTransaction>();
            mockSqlUnitOfWork
              .Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(mockTransaction.Object);

            mockSqlUnitOfWork
                .Setup(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception());

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(validRequest, CancellationToken.None));
        }
    }
}
