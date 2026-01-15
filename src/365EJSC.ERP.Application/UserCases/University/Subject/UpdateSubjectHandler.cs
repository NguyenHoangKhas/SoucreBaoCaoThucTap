using _365EJSC.ERP.Application.Requests.University.Subject;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Subject
{
    /// <summary>
    /// Handler for <see cref="UpdateSubjectRequest"/>
    /// </summary>
    public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectRequest, Result<object>>
    {
        private readonly ISubjectSqlRepository subjectSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public UpdateSubjectHandler(ISubjectSqlRepository subjectSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.subjectSqlRepository = subjectSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateSubjectRequest request, CancellationToken cancellationToken)
        {
            // Find existing subject by id
            Domain.Entities.University.Subject? subject = await subjectSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if subject exists
            if (subject == null)
            {
                throw new Exception("Subject not found");
            }

            // Update subject properties from request
            if (!string.IsNullOrEmpty(request.SubjectCode))
                subject.SubjectCode = request.SubjectCode;
            if (!string.IsNullOrEmpty(request.SubjectName))
                subject.SubjectName = request.SubjectName;
            if (request.Credits.HasValue)
                subject.Credits = request.Credits.Value;
            if (request.Description != null)
                subject.Description = request.Description;
            if (request.PrerequisiteId.HasValue)
                subject.PrerequisiteId = request.PrerequisiteId;

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked subject as Updated state
                subjectSqlRepository.Update(subject);

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
