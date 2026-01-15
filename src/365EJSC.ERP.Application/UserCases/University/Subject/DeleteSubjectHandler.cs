using _365EJSC.ERP.Application.Requests.University.Subject;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Subject
{
    /// <summary>
    /// Handler for <see cref="DeleteSubjectRequest"/>
    /// </summary>
    public class DeleteSubjectHandler : IRequestHandler<DeleteSubjectRequest, Result<object>>
    {
        private readonly ISubjectSqlRepository subjectSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteSubjectHandler(ISubjectSqlRepository subjectSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.subjectSqlRepository = subjectSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(DeleteSubjectRequest request, CancellationToken cancellationToken)
        {
            // Find existing subject by id
            Domain.Entities.University.Subject? subject = await subjectSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if subject exists
            if (subject == null)
            {
                throw new Exception("Subject not found");
            }

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked subject as Deleted state
                subjectSqlRepository.Remove(subject);

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