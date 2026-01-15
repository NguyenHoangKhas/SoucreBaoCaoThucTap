using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Grade
{
    public record GetAllGradeRequest : IQuery<IQueryable<Domain.Entities.University.Grade>>
    {
    }
}