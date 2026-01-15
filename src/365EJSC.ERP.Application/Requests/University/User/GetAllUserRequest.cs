using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.User
{
    public record GetAllUserRequest : IQuery<IQueryable<Domain.Entities.University.User>>
    {
    }
}