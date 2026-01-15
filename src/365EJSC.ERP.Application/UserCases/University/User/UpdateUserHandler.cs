using _365EJSC.ERP.Application.Requests.University.User;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.User
{
    /// <summary>
    /// Handler for <see cref="UpdateUserRequest"/>
    /// </summary>
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Result<object>>
    {
        private readonly IUserSqlRepository userSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public UpdateUserHandler(IUserSqlRepository userSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.userSqlRepository = userSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            // Find existing user by id
            Domain.Entities.University.User? user = await userSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if user exists
            if (user == null)
            {
                return Result<object>.Ok();
            }

            // Update user properties from request
            if (!string.IsNullOrEmpty(request.Username))
                user.Username = request.Username;
            if (request.FullName != null)
                user.FullName = request.FullName;
            if (request.Email != null)
                user.Email = request.Email;
            if (request.Role != null)
                user.Role = request.Role;

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked user as Updated state
                userSqlRepository.Update(user);

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
