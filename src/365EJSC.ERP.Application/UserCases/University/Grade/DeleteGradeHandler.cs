using _365EJSC.ERP.Application.Requests.University.Grade;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Grade
{
    /// <summary>
    /// Handler for <see cref="DeleteGradeRequest"/>
    /// </summary>
    public class DeleteGradeHandler : IRequestHandler<DeleteGradeRequest, Result<object>>
    {
        private readonly IGradeSqlRepository gradeSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteGradeHandler(IGradeSqlRepository gradeSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.gradeSqlRepository = gradeSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(DeleteGradeRequest request, CancellationToken cancellationToken)
        {
            // Find existing grade by id
            Domain.Entities.University.Grade? grade = await gradeSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if grade exists
            if (grade == null)
            {
                throw new Exception("Grade not found");
            }

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked grade as Deleted state
                gradeSqlRepository.Remove(grade);

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