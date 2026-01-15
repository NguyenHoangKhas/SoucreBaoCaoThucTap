using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Lecturer
{
    public record CreateLecturerRequest : ICommand
    {
        public string LecturerCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Degree { get; set; }
        public int UserId { get; set; }
    }
}