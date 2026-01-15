using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.CourseRegistration
{
    public record GetDetailCourseRegistrationRequest : IQuery<Domain.Entities.University.CourseRegistration>
    {
        public int? Id { get; set; }
    }
}