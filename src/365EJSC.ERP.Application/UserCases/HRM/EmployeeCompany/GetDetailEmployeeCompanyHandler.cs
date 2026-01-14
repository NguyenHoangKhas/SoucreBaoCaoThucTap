using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.Validators.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using MediatR;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany
{
    /// <summary>
    /// Handler for <see cref="GetDetailEmployeeCompanyRequest"/>
    /// </summary>
    public class GetDetailEmployeeCompanyHandler : IRequestHandler<GetDetailEmployeeCompanyRequest, Result<Entities.EmployeeCompany>>
    {
        /// <summary>
        /// Repository to handle data access of <see cref="Entities.EmployeeCompany"/>
        /// </summary>
        private readonly IEmployeeCompanySqlRepository employeeCompanySqlRepository;

        /// <summary>
        /// Constructor of <see cref="GetDetailEmployeeCompanyHandler"/>, inject needed dependency
        /// </summary>
        public GetDetailEmployeeCompanyHandler(IEmployeeCompanySqlRepository employeeCompanySqlRepository)
        {
            this.employeeCompanySqlRepository = employeeCompanySqlRepository;
        }

        /// <summary>
        /// Handle <see cref="GetDetailEmployeeCompanyRequest"/>, get <see cref="Entities.EmployeeCompany"/> from database with id provided in <see cref="GetDetailEmployeeCompanyRequest"/>.
        /// Throw not found exception when <see cref="Entities.EmployeeCompany"/> with id was not found
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with found <see cref="Entities.EmployeeCompany"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>
        public async Task<Result<Entities.EmployeeCompany>> Handle(GetDetailEmployeeCompanyRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request 
            GetDetailEmployeeCompanyValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find EmployeeCompany by id provided. If not found, throw NotFoundException
            var employeeCompany = employeeCompanySqlRepository.FindAll(x => x.Id.Equals(request.Id)).FirstOrDefault();
            if (employeeCompany is null)
                CustomException.ThrowNotFoundException(typeof(Entities.EmployeeCompany), MsgCode.ERR_EMPLOYEE_COMPANY_ID_NOT_FOUND);

            return Result<Entities.EmployeeCompany>.Ok(employeeCompany);
        }
    }
}
