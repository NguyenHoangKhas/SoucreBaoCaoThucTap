using _365EJSC.ERP.Application.Requests.University.LecturerSubject;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.LecturerSubject
{
    /// <summary>
    /// Handler for <see cref="CreateLecturerSubjectRequest"/>
    /// </summary>
    public class CreateLecturerSubjectHandler : IRequestHandler<CreateLecturerSubjectRequest, Result<object>>
    {
        private readonly ILecturerSubjectSqlRepository lecturerSubjectSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateLecturerSubjectHandler(ILecturerSubjectSqlRepository lecturerSubjectSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.lecturerSubjectSqlRepository = lecturerSubjectSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateLecturerSubjectRequest request, CancellationToken cancellationToken)
        {
            // Create new lecturer subject from request
            Domain.Entities.University.LecturerSubject? lecturerSubject = request.MapTo<Domain.Entities.University.LecturerSubject>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked lecturer subject as Created state
                lecturerSubjectSqlRepository.Add(lecturerSubject);

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