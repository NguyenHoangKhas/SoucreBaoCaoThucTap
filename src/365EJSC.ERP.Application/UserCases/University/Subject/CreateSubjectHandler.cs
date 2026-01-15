using _365EJSC.ERP.Application.Requests.University.Subject;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Subject
{
    /// <summary>
    /// Handler for <see cref="CreateSubjectRequest"/>
    /// </summary>
    public class CreateSubjectHandler : IRequestHandler<CreateSubjectRequest, Result<object>>
    {
        private readonly ISubjectSqlRepository subjectSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateSubjectHandler(ISubjectSqlRepository subjectSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.subjectSqlRepository = subjectSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateSubjectRequest request, CancellationToken cancellationToken)
        {
            // Create new subject from request
            Domain.Entities.University.Subject? subject = request.MapTo<Domain.Entities.University.Subject>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked subject as Created state
                subjectSqlRepository.Add(subject);

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