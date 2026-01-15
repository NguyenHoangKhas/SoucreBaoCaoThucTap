using _365EJSC.ERP.Application.Requests.University.Student;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Student
{
    /// <summary>
    /// Handler for <see cref="UpdateStudentRequest"/>
    /// </summary>
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentRequest, Result<object>>
    {
        private readonly IStudentSqlRepository studentSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public UpdateStudentHandler(IStudentSqlRepository studentSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.studentSqlRepository = studentSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateStudentRequest request, CancellationToken cancellationToken)
        {
            // Find existing student by id
            Domain.Entities.University.Student? student = await studentSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if student exists
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            // Update student properties from request
            if (!string.IsNullOrEmpty(request.StudentCode))
                student.StudentCode = request.StudentCode;
            if (request.FullName != null)
                student.FullName = request.FullName;
            if (request.Email != null)
                student.Email = request.Email;
            if (request.PhoneNumber != null)
                student.PhoneNumber = request.PhoneNumber;
            if (request.ClassId.HasValue)
                student.ClassId = request.ClassId;

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked student as Updated state
                studentSqlRepository.Update(student);

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