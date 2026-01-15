using _365EJSC.ERP.Application.Requests.University.Lecturer;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Lecturer
{
    /// <summary>
    /// Handler for <see cref="CreateLecturerRequest"/>
    /// </summary>
    public class CreateLecturerHandler : IRequestHandler<CreateLecturerRequest, Result<object>>
    {
        private readonly ILecturerSqlRepository lecturerSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateLecturerHandler(ILecturerSqlRepository lecturerSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.lecturerSqlRepository = lecturerSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateLecturerRequest request, CancellationToken cancellationToken)
        {
            // Create new lecturer from request
            Domain.Entities.University.Lecturer? lecturer = request.MapTo<Domain.Entities.University.Lecturer>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked lecturer as Created state
                lecturerSqlRepository.Add(lecturer);

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