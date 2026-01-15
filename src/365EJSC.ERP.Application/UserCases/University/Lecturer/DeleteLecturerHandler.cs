using _365EJSC.ERP.Application.Requests.University.Lecturer;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Lecturer
{
    /// <summary>
    /// Handler for <see cref="DeleteLecturerRequest"/>
    /// </summary>
    public class DeleteLecturerHandler : IRequestHandler<DeleteLecturerRequest, Result<object>>
    {
        private readonly ILecturerSqlRepository lecturerSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteLecturerHandler(ILecturerSqlRepository lecturerSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.lecturerSqlRepository = lecturerSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(DeleteLecturerRequest request, CancellationToken cancellationToken)
        {
            // Find existing lecturer by id
            Domain.Entities.University.Lecturer? lecturer = await lecturerSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if lecturer exists
            if (lecturer == null)
            {
                throw new Exception("Lecturer not found");
            }

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked lecturer as Deleted state
                lecturerSqlRepository.Remove(lecturer);

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