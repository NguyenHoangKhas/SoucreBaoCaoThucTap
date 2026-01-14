using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.Bank
{
    public record GetDetailBankRequest : IQuery<Domain.Entities.HRM.Bank>
    {
        public int? Id { get; set; }
    }
}
