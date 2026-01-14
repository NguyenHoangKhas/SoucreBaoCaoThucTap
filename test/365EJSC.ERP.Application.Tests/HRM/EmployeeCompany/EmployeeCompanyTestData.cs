using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Tests.HRM.EmployeeCompany
{
    public class EmployeeCompanyTestData
    {
        public static IEnumerable<Entities.EmployeeCompany> GetSample()
        {
            return new List<Entities.EmployeeCompany>
            {
                new Entities.EmployeeCompany
                {
                    Id = 1,
                    EmployeeId = 1,
                    CdId = 1
                },
                new Entities.EmployeeCompany
                {
                    Id = 2,
                    EmployeeId = 2,
                    CdId = 1
                },
                new Entities.EmployeeCompany
                {
                    Id = 3,
                    EmployeeId = 1,
                    CdId = 2
                },
                new Entities.EmployeeCompany
                {
                    Id = 4,
                    EmployeeId = 3,
                    CdId = 3
                }
            };
        }
    }
}
