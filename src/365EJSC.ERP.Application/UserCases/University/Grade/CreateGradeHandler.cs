using _365EJSC.ERP.Application.Requests.University.Grade;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Grade
{
    /// <summary>
    /// Handler for <see cref="CreateGradeRequest"/>
    /// </summary>
    public class CreateGradeHandler : IRequestHandler<CreateGradeRequest, Result<object>>
    {
        private readonly IGradeSqlRepository gradeSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateGradeHandler(IGradeSqlRepository gradeSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.gradeSqlRepository = gradeSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateGradeRequest request, CancellationToken cancellationToken)
        {
            // Create new grade from request
            Domain.Entities.University.Grade? grade = request.MapTo<Domain.Entities.University.Grade>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked grade as Created state
                gradeSqlRepository.Add(grade);

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
