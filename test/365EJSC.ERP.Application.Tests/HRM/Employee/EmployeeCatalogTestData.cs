using _365EJSC.ERP.Domain.Entities.HRM;
using HrmEntities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.Employee
{
    public static class EmployeeCatalogTestData
    {
        public static IEnumerable<HrmEntities.Employee> GetSample()
        {
            return [
                new() {
                    Id = 1,
                    EmpCode = "C001",
                    EmpFirstName = "Emp",
                    BankId = 1,
                    CountryId = "VN",
                    EmpPlaceOfResidenceWardId = 101,
                    EmployeeVerifies = [new EmployeeVerify { VerCreatedDate=123123, Id = 1 }],
                    EmpGender = false,
                   // CountryInfo = new WebLocals { Id = "L1", Localization = "Local Z" },
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
                    //},
                    Password = BCrypt.Net.BCrypt.HashPassword("password123"),
                    CompanyId = 1,
                    //CompanyInfo = CompanyTestData.GetSample().FirstOrDefault()
                },
                new() {
                    Id = 2,
                    EmpCode = "C002",
                    EmpFirstName = "Emp",
                    BankId = 2,
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
                    //},
                    Password = BCrypt.Net.BCrypt.HashPassword("password123"),
                    CompanyId = 1,
                    //CompanyInfo = CompanyTestData.GetSample().FirstOrDefault()
                },
            ];
        }
    }
}
