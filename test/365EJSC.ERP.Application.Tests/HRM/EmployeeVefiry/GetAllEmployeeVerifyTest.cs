using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Application.UserCases.HRM.EmployeeVerify;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.DTOs.HRM;
using _365EJSC.ERP.Domain.Entities.Define;
using _365EJSC.ERP.Domain.Entities.HRM;
using Moq;
using HrmEntities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeVerifyVefiry
{
    public class GetAllEmployeeVerifyTest
    {
        private readonly Mock<IEmployeeVerifySqlRepository> mockGeneralDepartmentRepository;
        private readonly Mock<IFileService> mockFileService;
        private readonly GetAllEmployeeVerifyHandler handler;
        private readonly IEnumerable<EmployeeVerify> validEmployeeVerifies;

        public GetAllEmployeeVerifyTest()
        {
            mockGeneralDepartmentRepository = new Mock<IEmployeeVerifySqlRepository>();
            mockFileService = new Mock<IFileService>();
            handler = new GetAllEmployeeVerifyHandler(mockGeneralDepartmentRepository.Object, mockFileService.Object);
            var employee = new HrmEntities.Employee() {
                Id = 1,
                EmpCode = "C001",
                EmpFirstName = "Emp",
                BankId = 1,
                CountryId = "VN",
                EmpPlaceOfResidenceWardId = 101,
                EmployeeVerifies = [new EmployeeVerify { VerCreatedDate=123123, Id = 1 }],
                EmpGender = false,
                //CountryInfo = new WebLocals { Id = "L1", Localization = "Local Z" },
                DegreeId = 1,
                DegreeInfo = new HrmEntities.Degree {Id = 1, DegreeName = "D1"},
                EmpJoinedDate = 123123,
                IsActived = 1,
                BankInfo = new HrmEntities.Bank { Id = 1, BankName = "Bank A" },
                //EmpPlaceOfBirthInfo = new WebLocalProvince { Id = 10, ProvinceName = "Province Y" },
                EmpAccountNumber = "123",
                EmpEducationLevel = "Master",
                EmpEmail = "test@test.test",
                EmpPlaceOfResidenceAddress = "Campuchia",
                EmpRoleId = 1,
                EmpCitizenIdentity = "VN2",
                MaritalId = 1,
                NationId = 1,
                ReligionId = 1,
                TraMajId = 1,
                EmpRoleInfo = new HrmEntities.EmployeeRole{Id = 1, EmpRoleName = "TTS", EmpRoleCode = "123"},
                //MaritalInfo = new HrmEntities.Marital{Id = 1, MaritalName = "MN"},
                //NationInfo = new HrmEntities.Nation {Id = 1, NationName = "N1"},
                //ReligionInfo = new HrmEntities.Religion {Id = 1, ReligionName = "R1"},
                //TraMajInfo = new HrmEntities.TrainingMajor {Id = 1, TrainingMajorName = "TM1" },
                //EmpPlaceOfResidenceWardIdInfo = new WebLocalWard
                //{
                //    Id = 101,
                //    WardName = "Ward A",
                //    WebLocalDistrict = new WebLocalDistrict
                //    {
                //        Id = 5,
                //        DistrictName = "District X",
                //        WebLocalProvince = new WebLocalProvince
                //        {
                //            Id = 10,
                //            ProvinceName = "Province Y",
                //            WebLocal = new WebLocals { Id = "L1", Localization = "Local Z" }
                //        }
                //    }
                //}    
            };
            validEmployeeVerifies = [
                new EmployeeVerify() {
                    Id = 1,
                    IsActived = 1,
                    EmployeeId = 1,
                    VerImage = "https://server.com/path/to/image.jpg",
                    UserIdVerify = 1,
                    VerCreatedDate = 20240317,
                    Employee = employee
                },
                new EmployeeVerify() {
                    Id = 2,
                    IsActived = 1,
                    EmployeeId = 1,
                    VerImage = "https://server.com/path/to/image.jpg",
                    UserIdVerify = 1,
                    VerCreatedDate = 20240317,
                    Employee = employee
                },
            ];
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyList_When_NoEmployeeVerify()
        {
            // Arrange
            mockGeneralDepartmentRepository.Setup(r => r.FindAll(null, false)).Returns(new List<EmployeeVerify>().AsQueryable());
            var query = new GetAllEmployeeVerifyRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Data);
        }

        [Fact]
        public async Task Handle_Should_ReturnAllEmployeeVerify()
        {
            // Arrange
            var EmployeeVerify = new List<EmployeeVerify>
            {
                new() { Id = 1 },
                new() { Id = 2 }
            };
            mockGeneralDepartmentRepository.Setup(repository => repository.FindAll(null, false)).Returns(validEmployeeVerifies.AsQueryable());
            var query = new GetAllEmployeeVerifyRequest();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data.Cast<EmployeeVerifyDTOs>().Count());
        }
    }
}
