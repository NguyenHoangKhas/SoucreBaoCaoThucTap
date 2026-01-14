using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany
{
    public class GetDetailEmployeeCompanyRequest : IQuery<Domain.Entities.HRM.EmployeeCompany>
    {
        public int Id { get; set; }
    }
}
