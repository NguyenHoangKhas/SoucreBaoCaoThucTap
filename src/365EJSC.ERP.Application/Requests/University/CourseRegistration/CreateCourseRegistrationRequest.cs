using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.CourseRegistration
{
    public record CreateCourseRegistrationRequest : ICommand
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string? Semester { get; set; }
        public string? AcademicYear { get; set; }
        public string? Status { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}