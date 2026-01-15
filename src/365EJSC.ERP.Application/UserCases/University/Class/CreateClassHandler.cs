using _365EJSC.ERP.Application.Requests.University.Class;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Class
{
    /// <summary>
    /// Handler for <see cref="CreateClassRequest"/>
    /// </summary>
    public class CreateClassHandler : IRequestHandler<CreateClassRequest, Result<object>>
    {
        private readonly IClassSqlRepository classSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateClassHandler(IClassSqlRepository classSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.classSqlRepository = classSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateClassRequest request, CancellationToken cancellationToken)
        {
            // Create new class from request
            Domain.Entities.University.Class? classEntity = request.MapTo<Domain.Entities.University.Class>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked class as Created state
                classSqlRepository.Add(classEntity);

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
