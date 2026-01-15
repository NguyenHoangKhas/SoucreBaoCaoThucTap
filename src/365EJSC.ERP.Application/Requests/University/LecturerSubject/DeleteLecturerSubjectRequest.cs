using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.LecturerSubject
{
    public record DeleteLecturerSubjectRequest : ICommand
    {
        public int? Id { get; set; }
    }
}