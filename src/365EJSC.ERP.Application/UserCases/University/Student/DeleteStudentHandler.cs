using _365EJSC.ERP.Application.Requests.University.Student;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Student
{
    /// <summary>
    /// Handler for <see cref="DeleteStudentRequest"/>
    /// </summary>
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, Result<object>>
    {
        private readonly IStudentSqlRepository studentSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteStudentHandler(IStudentSqlRepository studentSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.studentSqlRepository = studentSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            // Find existing student by id
            Domain.Entities.University.Student? student = await studentSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if student exists
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked student as Deleted state
                studentSqlRepository.Remove(student);

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