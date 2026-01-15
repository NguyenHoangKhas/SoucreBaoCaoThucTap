using _365EJSC.ERP.Application.Requests.University.CourseRegistration;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.CourseRegistration
{
    /// <summary>
    /// Handler for <see cref="GetDetailCourseRegistrationRequest"/>
    /// </summary>
    public class GetDetailCourseRegistrationHandler : IRequestHandler<GetDetailCourseRegistrationRequest, Result<Domain.Entities.University.CourseRegistration>>
    {
        private readonly ICourseRegistrationSqlRepository courseRegistrationSqlRepository;

        public GetDetailCourseRegistrationHandler(ICourseRegistrationSqlRepository courseRegistrationSqlRepository)
        {
            this.courseRegistrationSqlRepository = courseRegistrationSqlRepository;
        }

        public async Task<Result<Domain.Entities.University.CourseRegistration>> Handle(GetDetailCourseRegistrationRequest request, CancellationToken cancellationToken)
        {
            // Find course registration by id
            Domain.Entities.University.CourseRegistration? courseRegistration = await courseRegistrationSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: false, cancellationToken);

            // Check if course registration exists
            if (courseRegistration == null)
            {
                throw new Exception("Course Registration not found");
            }

            // Return success result with data
            return Result<Domain.Entities.University.CourseRegistration>.Ok(courseRegistration);
        }
    }
}