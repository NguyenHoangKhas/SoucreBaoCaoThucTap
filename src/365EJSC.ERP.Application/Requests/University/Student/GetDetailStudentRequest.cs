using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Student
{
    public record GetDetailStudentRequest : IQuery<Domain.Entities.University.Student>
    {
        public int? Id { get; set; }
    }
}