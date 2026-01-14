using _365EJSC.ERP.Application.Tests.HRM.Employee;
using _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeVefiry
{
    public static class EmployeeVerifyTestData
    {
        public static IEnumerable<EmployeeVerify> GetSample()
            => [
                new(){
                    Id = 1,
                    EmployeeId = 1,
                    IsActived = 1,
                    UserIdVerify = 1,
                    VerImage = "image.png",
                    VerCreatedDate = 16042025,
                    Employee = EmployeeCatalogTestData.GetSample().FirstOrDefault()
                }
            ];
    }
}
