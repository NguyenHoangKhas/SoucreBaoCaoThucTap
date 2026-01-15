using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.CourseRegistration
{
    public record GetAllCourseRegistrationRequest : IQuery<IQueryable<Domain.Entities.University.CourseRegistration>>
    {
    }
}