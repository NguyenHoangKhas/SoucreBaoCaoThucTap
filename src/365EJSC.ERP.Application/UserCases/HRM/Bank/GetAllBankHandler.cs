using _365EJSC.ERP.Application.Requests.HRM.Bank;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using EntitiesHRM = _365EJSC.ERP.Domain.Entities.HRM;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.HRM.Bank
{
    public class GetAllBankHandler : IRequestHandler<GetAllBankRequest, Result<IQueryable<EntitiesHRM.Bank>>>
    {
        private readonly IBankSqlRepository bankSqlRepository;

        public GetAllBankHandler(IBankSqlRepository bankSqlRepository)
        {
            this.bankSqlRepository = bankSqlRepository;
        }
        public Task<Result<IQueryable<EntitiesHRM.Bank>>> Handle(GetAllBankRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Result<IQueryable<EntitiesHRM.Bank>>.Ok(bankSqlRepository.FindAll().OrderBy(x => x.BankName).AsQueryable()));
        }
    }
}
