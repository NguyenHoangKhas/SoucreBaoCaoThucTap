using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.CourseRegistration
{
    public record DeleteCourseRegistrationRequest : ICommand
    {
        public int? Id { get; set; }
    }
}