using _365EJSC.ERP.Application.Requests.University.LecturerSubject;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.LecturerSubject
{
    /// <summary>
    /// Handler for <see cref="DeleteLecturerSubjectRequest"/>
    /// </summary>
    public class DeleteLecturerSubjectHandler : IRequestHandler<DeleteLecturerSubjectRequest, Result<object>>
    {
        private readonly ILecturerSubjectSqlRepository lecturerSubjectSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteLecturerSubjectHandler(ILecturerSubjectSqlRepository lecturerSubjectSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.lecturerSubjectSqlRepository = lecturerSubjectSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(DeleteLecturerSubjectRequest request, CancellationToken cancellationToken)
        {
            // Find existing lecturer subject by id
            Domain.Entities.University.LecturerSubject? lecturerSubject = await lecturerSubjectSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if lecturer subject exists
            if (lecturerSubject == null)
            {
                throw new Exception("Lecturer Subject not found");
            }

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked lecturer subject as Deleted state
                lecturerSubjectSqlRepository.Remove(lecturerSubject);

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