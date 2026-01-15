using _365EJSC.ERP.Application.Requests.University.Class;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Class
{
    /// <summary>
    /// Handler for <see cref="DeleteClassRequest"/>
    /// </summary>
    public class DeleteClassHandler : IRequestHandler<DeleteClassRequest, Result<object>>
    {
        private readonly IClassSqlRepository classSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public DeleteClassHandler(IClassSqlRepository classSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.classSqlRepository = classSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(DeleteClassRequest request, CancellationToken cancellationToken)
        {
            // Find existing class by id
            Domain.Entities.University.Class? classEntity = await classSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if class exists
            if (classEntity == null)
            {
                throw new Exception("Class not found");
            }

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked class as Deleted state
                classSqlRepository.Remove(classEntity);

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