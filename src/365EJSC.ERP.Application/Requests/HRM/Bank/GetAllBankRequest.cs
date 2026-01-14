using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.Bank
{
    public record GetAllBankRequest : IQuery<IQueryable<Domain.Entities.HRM.Bank>>
    {
    }
}
