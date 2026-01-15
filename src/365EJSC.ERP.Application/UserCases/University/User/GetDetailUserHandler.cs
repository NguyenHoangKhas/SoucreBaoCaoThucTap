using _365EJSC.ERP.Application.Requests.University.User;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.User
{
    /// <summary>
    /// Handler for <see cref="GetDetailUserRequest"/>
    /// </summary>
    public class GetDetailUserHandler : IRequestHandler<GetDetailUserRequest, Result<Domain.Entities.University.User>>
    {
        private readonly IUserSqlRepository userSqlRepository;

        public GetDetailUserHandler(IUserSqlRepository userSqlRepository)
        {
            this.userSqlRepository = userSqlRepository;
        }

        public async Task<Result<Domain.Entities.University.User>> Handle(GetDetailUserRequest request, CancellationToken cancellationToken)
        {
            // Find user by id
            Domain.Entities.University.User? user = await userSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: false, cancellationToken);

            // Check if user exists
            if (user == null)
            {
                return Result<Domain.Entities.University.User>.Ok();
            }

            // Return success result with data
            return Result<Domain.Entities.University.User>.Ok(user);
        }
    }
}