using _365EJSC.ERP.Contract.Abstractions;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.Requests.HRM.DefineContractTypes
{
    public record GetAllContractTypeRequest : IQuery<IQueryable<Entities.DefineContractTypes>>
    {
    }
}
