using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Student
{
    public record DeleteStudentRequest : ICommand
    {
        public int? Id { get; set; }
    }
}
