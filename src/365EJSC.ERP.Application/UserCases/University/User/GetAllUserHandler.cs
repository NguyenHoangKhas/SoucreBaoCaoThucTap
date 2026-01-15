using _365EJSC.ERP.Application.Requests.University.User;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.User
{
    /// <summary>
    /// Handler for <see cref="GetAllUserRequest"/>
    /// </summary>
    public class GetAllUserHandler : IRequestHandler<GetAllUserRequest, Result<IQueryable<Domain.Entities.University.User>>>
    {
        private readonly IUserSqlRepository userSqlRepository;

        public GetAllUserHandler(IUserSqlRepository userSqlRepository)
        {
            this.userSqlRepository = userSqlRepository;
        }

        public async Task<Result<IQueryable<Domain.Entities.University.User>>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            // Get all users
            IQueryable<Domain.Entities.University.User> users = userSqlRepository.FindAll();

            // Return success result with data
            return await Task.FromResult(Result<IQueryable<Domain.Entities.University.User>>.Ok(users));
        }
    }
}
