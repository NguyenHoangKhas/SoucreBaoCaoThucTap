using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Class
{
    public record GetAllClassRequest : IQuery<IQueryable<Domain.Entities.University.Class>>
    {
    }
}