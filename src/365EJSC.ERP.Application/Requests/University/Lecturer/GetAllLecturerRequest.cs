using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Lecturer
{
    public record GetAllLecturerRequest : IQuery<IQueryable<Domain.Entities.University.Lecturer>>
    {
    }
}