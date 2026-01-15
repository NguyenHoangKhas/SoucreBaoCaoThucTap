using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Subject
{
    public record GetAllSubjectRequest : IQuery<IQueryable<Domain.Entities.University.Subject>>
    {
    }
}