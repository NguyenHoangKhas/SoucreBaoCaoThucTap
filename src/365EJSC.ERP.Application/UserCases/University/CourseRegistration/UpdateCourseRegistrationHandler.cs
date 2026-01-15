using _365EJSC.ERP.Application.Requests.University.CourseRegistration;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.CourseRegistration
{
    /// <summary>
    /// Handler for <see cref="UpdateCourseRegistrationRequest"/>
    /// </summary>
    public class UpdateCourseRegistrationHandler : IRequestHandler<UpdateCourseRegistrationRequest, Result<object>>
    {
        private readonly ICourseRegistrationSqlRepository courseRegistrationSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public UpdateCourseRegistrationHandler(ICourseRegistrationSqlRepository courseRegistrationSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.courseRegistrationSqlRepository = courseRegistrationSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateCourseRegistrationRequest request, CancellationToken cancellationToken)
        {
            // Find existing course registration by id
            Domain.Entities.University.CourseRegistration? courseRegistration = await courseRegistrationSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if course registration exists
            if (courseRegistration == null)
            {
                throw new Exception("Course Registration not found");
            }

            // Update course registration properties from request
            if (request.Semester != null)
                courseRegistration.Semester = request.Semester;
            if (request.AcademicYear != null)
                courseRegistration.AcademicYear = request.AcademicYear;
            if (request.Status != null)
                courseRegistration.Status = request.Status;

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked course registration as Updated state
                courseRegistrationSqlRepository.Update(courseRegistration);

                // Save data to database
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Commit transaction
                transaction.Commit();

                // Return success result
                return Result<object>.Ok();
            }
            catch (Exception)
            {
                // Rollback transaction if any exception happened, then throw exception
                transaction.Rollback();
                throw;
            }
        }
    }
}