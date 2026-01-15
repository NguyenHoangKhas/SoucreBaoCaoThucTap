using _365EJSC.ERP.Application.Requests.University.CourseRegistration;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.CourseRegistration
{
    /// <summary>
    /// Handler for <see cref="CreateCourseRegistrationRequest"/>
    /// </summary>
    public class CreateCourseRegistrationHandler : IRequestHandler<CreateCourseRegistrationRequest, Result<object>>
    {
        private readonly ICourseRegistrationSqlRepository courseRegistrationSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateCourseRegistrationHandler(ICourseRegistrationSqlRepository courseRegistrationSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.courseRegistrationSqlRepository = courseRegistrationSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateCourseRegistrationRequest request, CancellationToken cancellationToken)
        {
            // Create new course registration from request
            Domain.Entities.University.CourseRegistration? courseRegistration = request.MapTo<Domain.Entities.University.CourseRegistration>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked course registration as Created state
                courseRegistrationSqlRepository.Add(courseRegistration);

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
