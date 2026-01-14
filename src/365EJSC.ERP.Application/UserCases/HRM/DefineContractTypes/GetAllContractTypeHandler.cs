using _365EJSC.ERP.Application.Requests.HRM.DefineContractTypes;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.HRM.DefineContractTypes
{
    public class GetAllContractTypeHandler : IRequestHandler<GetAllContractTypeRequest, Result<IQueryable<Domain.Entities.HRM.DefineContractTypes>>>
    {
        /// <summary>
        /// Repo/// Repository handle data access of <see cref="Domain.Entities.HRM.DefineContractTypes"/>>  /// </summary>
        private readonly IContractTypeSqlRepository contractTypeSqlRepository;

        /// <summary>
        /// Constructor of <see cref="GetAllContractTypeHandler"/>, inject needed dependency
        /// </summary>
        public GetAllContractTypeHandler(IContractTypeSqlRepository contractTypeSqlRepository)
        {
            this.contractTypeSqlRepository = contractTypeSqlRepository;
        }

        /// <summary>
        /// Handle <see cref="GetAllContractTypeRequest"/>, get all DefineContractType in database, can skip a number of records and limit record taken
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with list of <see cref="Domain.Entities.HRM.DefineContractTypes"/></returns>
        /// <exception cref="Exception"></exception>
        public Task<Result<IQueryable<Domain.Entities.HRM.DefineContractTypes>>> Handle(GetAllContractTypeRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Result<IQueryable<Domain.Entities.HRM.DefineContractTypes>>.Ok(contractTypeSqlRepository.FindAll().OrderBy(x => x.ContractTypeName).AsQueryable()));
        }
    }
}
