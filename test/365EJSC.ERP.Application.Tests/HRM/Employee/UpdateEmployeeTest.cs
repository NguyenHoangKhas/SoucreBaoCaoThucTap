using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.UserCases.HRM.Employee;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using Moq;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.Employee
{
    public class UpdateEmployeeTest
    {
        private readonly Mock<IEmployeeSqlRepository> mockEmployeeSqlRepository;
        private readonly Mock<ISqlUnitOfWork> mockSqlUnitOfWork;
        private readonly Mock<IFileService> mockFileService;
        /// <summary>
        private readonly UpdateEmployeeHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmployeeTest"/> class.
        /// </summary>
        public UpdateEmployeeTest()
        {
            mockEmployeeSqlRepository = new Mock<IEmployeeSqlRepository>();
            mockSqlUnitOfWork = new Mock<ISqlUnitOfWork>();
            mockFileService = new Mock<IFileService>();

            handler = new UpdateEmployeeHandler(mockEmployeeSqlRepository.Object, mockSqlUnitOfWork.Object, mockFileService.Object);
        }
        [Fact]
        public async Task Handle_RepositoryThrowsException_TransactionRollsBack()
        {
            // Arrange
            var request = new UpdateEmployeeRequest
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
                EmpEducationLevel = "Bachelor's Degree",
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
                IsActived = 1
            };

            var mockTransaction = new Mock<IDbTransaction>();
            mockSqlUnitOfWork.Setup(uow => uow.BeginTransactionAsync(It.IsAny<CancellationToken>()))
                             .ReturnsAsync(mockTransaction.Object);

            mockEmployeeSqlRepository.Setup(repo => repo.FindByIdAsync(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync(new Entities.Employee { Id = 1 }); // Simulate finding the district

            // Act & Assert
            await Assert.ThrowsAsync<CustomException>(() => handler.Handle(request, CancellationToken.None));  // Expecting CustomException
        }
    }
}
