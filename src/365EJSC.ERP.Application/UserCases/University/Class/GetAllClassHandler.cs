using _365EJSC.ERP.Application.Requests.University.Class;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Class
{
    /// <summary>
    /// Handler for <see cref="GetAllClassRequest"/>
    /// </summary>
    public class GetAllClassHandler : IRequestHandler<GetAllClassRequest, Result<IQueryable<Domain.Entities.University.Class>>>
    {
        private readonly IClassSqlRepository classSqlRepository;

        public GetAllClassHandler(IClassSqlRepository classSqlRepository)
        {
            this.classSqlRepository = classSqlRepository;
        }

        public async Task<Result<IQueryable<Domain.Entities.University.Class>>> Handle(GetAllClassRequest request, CancellationToken cancellationToken)
        {
            // Get all classes
            IQueryable<Domain.Entities.University.Class> classes = classSqlRepository.FindAll();

            // Return success result with data
            return await Task.FromResult(Result<IQueryable<Domain.Entities.University.Class>>.Ok(classes));
        }
    }
}
