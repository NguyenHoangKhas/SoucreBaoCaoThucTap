using _365EJSC.ERP.Application.Requests.HRM.DefineContractTypes;
using _365EJSC.ERP.Application.Validators.HRM.DefineContractTypes;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.HRM.DefineContractTypes
{
    public class GetDetailContractTypeHandler : IRequestHandler<GetDetailContractTypeRequest, Result<Domain.Entities.HRM.DefineContractTypes>>
    {
        /// <summary>
        /// Repo/// Repository handle data access of <see cref="Domain.Entities.HRM.DefineContractTypes"/>>  /// </summary>
        private readonly IContractTypeSqlRepository contractTypeSqlRepository;

        /// <summary>
        /// Constructor of <see cref="GetDetailContractTypeHandler"/>, inject needed dependency
        /// </summary>
        public GetDetailContractTypeHandler(IContractTypeSqlRepository contractTypeSqlRepository)
        {
            this.contractTypeSqlRepository = contractTypeSqlRepository;
        }

        /// <summary>
        /// Handle <see cref="GetDetailContractTypeRequest"/>, get <see cref="Domain.Entities.HRM.DefineContractTypes"/> from database with id provided in <see cref="GetDetailGeneralPositionRequest"/>.
        /// Throw not found exception when <see cref="Domain.Entities.HRM.DefineContractTypes"/> with id was not found
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with founded <see cref="Domain.Entities.HRM.DefineContractTypes"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>>
        public async Task<Result<Domain.Entities.HRM.DefineContractTypes>> Handle(GetDetailContractTypeRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request 
            GetDetailContractTypeValidator validator = new();
            validator.ValidateAndThrow(request);

            var defineContractType = await contractTypeSqlRepository.FindByIdAsync((int)request.Id, false, cancellationToken);

            if (defineContractType is null)
            {
                CustomException.ThrowNotFoundException(typeof(Domain.Entities.HRM.DefineContractTypes), MsgCode.ERR_CONTRACT_TYPE_ID_NOT_FOUND);
            }

            return defineContractType;
        }
    }
}
