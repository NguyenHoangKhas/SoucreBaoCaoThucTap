using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Lecturer
{
    public record DeleteLecturerRequest : ICommand
    {
        public int? Id { get; set; }
    }
}