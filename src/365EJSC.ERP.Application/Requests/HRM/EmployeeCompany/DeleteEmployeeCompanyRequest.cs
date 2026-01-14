using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany
{
    public class DeleteEmployeeCompanyRequest : ICommand
    {
        public int Id { get; set; }
    }
}
