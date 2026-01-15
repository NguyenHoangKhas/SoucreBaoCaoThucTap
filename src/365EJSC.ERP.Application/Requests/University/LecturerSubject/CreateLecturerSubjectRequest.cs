using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.LecturerSubject
{
    public record CreateLecturerSubjectRequest : ICommand
    {
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }
        public string? Semester { get; set; }
        public string? AcademicYear { get; set; }
    }
}