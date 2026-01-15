using _365EJSC.ERP.Application.Requests.University.Class;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Class
{
    /// <summary>
    /// Handler for <see cref="GetDetailClassRequest"/>
    /// </summary>
    public class GetDetailClassHandler : IRequestHandler<GetDetailClassRequest, Result<Domain.Entities.University.Class>>
    {
        private readonly IClassSqlRepository classSqlRepository;

        public GetDetailClassHandler(IClassSqlRepository classSqlRepository)
        {
            this.classSqlRepository = classSqlRepository;
        }

        public async Task<Result<Domain.Entities.University.Class>> Handle(GetDetailClassRequest request, CancellationToken cancellationToken)
        {
            // Find class by id
            Domain.Entities.University.Class? classEntity = await classSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: false, cancellationToken);

            // Check if class exists
            if (classEntity == null)
            {
                throw new Exception("Class not found");
            }

            // Return success result with data
            return Result<Domain.Entities.University.Class>.Ok(classEntity);
        }
    }
}