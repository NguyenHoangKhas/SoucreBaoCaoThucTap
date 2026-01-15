using _365EJSC.ERP.Application.Requests.University.Student;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Student
{
    /// <summary>
    /// Handler for <see cref="CreateStudentRequest"/>
    /// </summary>
    public class CreateStudentHandler : IRequestHandler<CreateStudentRequest, Result<object>>
    {
        private readonly IStudentSqlRepository studentSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateStudentHandler(IStudentSqlRepository studentSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.studentSqlRepository = studentSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateStudentRequest request, CancellationToken cancellationToken)
        {
            // Create new student from request
            Domain.Entities.University.Student? student = request.MapTo<Domain.Entities.University.Student>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked student as Created state
                studentSqlRepository.Add(student);

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