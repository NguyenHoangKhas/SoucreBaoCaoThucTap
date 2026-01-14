using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using MediatR;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany
{
    /// <summary>
    /// Handler for <see cref="GetAllEmployeeCompanyRequest"/>
    /// </summary>
    public class GetAllEmployeeCompanyHandler : IRequestHandler<GetAllEmployeeCompanyRequest, Result<IQueryable<Entities.EmployeeCompany>>>
    {
        /// <summary>
        /// Repository to handle data access of <see cref="Entities.EmployeeCompany"/>
        /// </summary>
        private readonly IEmployeeCompanySqlRepository employeeCompanySqlRepository;

        /// <summary>
        /// Constructor of <see cref="GetAllEmployeeCompanyHandler"/>, inject needed dependency
        /// </summary>
        public GetAllEmployeeCompanyHandler(IEmployeeCompanySqlRepository employeeCompanySqlRepository)
        {
            this.employeeCompanySqlRepository = employeeCompanySqlRepository;
        }

        /// <summary>
        /// Handle <see cref="GetAllEmployeeCompanyRequest"/>, get all EmployeeCompany entities in database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with list of <see cref="Entities.EmployeeCompany"/></returns>
        /// <exception cref="Exception"></exception>
        public Task<Result<IQueryable<Entities.EmployeeCompany>>> Handle(GetAllEmployeeCompanyRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Result<IQueryable<Entities.EmployeeCompany>>.Ok(employeeCompanySqlRepository.FindAll()));
        }
    }
}
