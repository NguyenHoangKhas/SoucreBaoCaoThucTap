using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Student
{
    public record GetAllStudentRequest : IQuery<IQueryable<Domain.Entities.University.Student>>
    {
    }
}