using _365EJSC.ERP.Application.Requests.University.CourseRegistration;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.CourseRegistration
{
    /// <summary>
    /// Handler for <see cref="GetAllCourseRegistrationRequest"/>
    /// </summary>
    public class GetAllCourseRegistrationHandler : IRequestHandler<GetAllCourseRegistrationRequest, Result<IQueryable<Domain.Entities.University.CourseRegistration>>>
    {
        private readonly ICourseRegistrationSqlRepository courseRegistrationSqlRepository;

        public GetAllCourseRegistrationHandler(ICourseRegistrationSqlRepository courseRegistrationSqlRepository)
        {
            this.courseRegistrationSqlRepository = courseRegistrationSqlRepository;
        }

        public async Task<Result<IQueryable<Domain.Entities.University.CourseRegistration>>> Handle(GetAllCourseRegistrationRequest request, CancellationToken cancellationToken)
        {
            // Get all course registrations
            IQueryable<Domain.Entities.University.CourseRegistration> courseRegistrations = courseRegistrationSqlRepository.FindAll();

            // Return success result with data
            return await Task.FromResult(Result<IQueryable<Domain.Entities.University.CourseRegistration>>.Ok(courseRegistrations));
        }
    }
}