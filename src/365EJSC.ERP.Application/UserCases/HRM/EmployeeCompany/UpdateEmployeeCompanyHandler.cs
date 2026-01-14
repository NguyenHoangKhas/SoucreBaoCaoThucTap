using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.Validators.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Domain.Entities.HRM;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany
{
    /// <summary>
    /// Handler for <see cref="UpdateEmployeeCompanyRequest"/>
    /// </summary>
    public class UpdateEmployeeCompanyHandler : IRequestHandler<UpdateEmployeeCompanyRequest, Result<object>>
    {
        /// <summary>
        /// Repository to handle data access of <see cref="Entities.EmployeeCompany"/>
        /// </summary>
        private readonly IEmployeeCompanySqlRepository employeeCompanySqlRepository;

        /// <summary>
        /// Unit of work to handle transaction
        /// </summary>
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        /// <summary>
        /// Constructor of <see cref="UpdateEmployeeCompanyHandler"/>, inject needed dependency
        /// </summary>
        public UpdateEmployeeCompanyHandler(IEmployeeCompanySqlRepository employeeCompanySqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.employeeCompanySqlRepository = employeeCompanySqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        /// <summary>
        /// Handle <see cref="UpdateEmployeeCompanyRequest"/>, update an existing <see cref="Entities.EmployeeCompany"/> based on data from <see cref="UpdateEmployeeCompanyRequest"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(UpdateEmployeeCompanyRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            UpdateEmployeeCompanyValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find existing EmployeeCompany by ID
            var employeeCompany = await employeeCompanySqlRepository.FindByIdAsync(request.Id, true, cancellationToken);
            if (employeeCompany is null)
                CustomException.ThrowNotFoundException(typeof(Entities.EmployeeCompany), MsgCode.ERR_EMPLOYEE_COMPANY_ID_NOT_FOUND);

            // Check exist employee company
            var isExist = employeeCompanySqlRepository.FindAll(x => x.EmployeeId.Equals(request.EmployeeId ?? employeeCompany.EmployeeId) && x.CdId.Equals(request.CdId ?? employeeCompany.CdId)).Any();
            if (isExist) return Result<object>.Ok();

            // Validate EmployeeId and CdId if provided
            await employeeCompanySqlRepository.ValidateEmployeeCompany(request.EmployeeId, request.CdId);

            // Update fields if provided
            request.MapTo(employeeCompany, true);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Mark employeeCompany as Updated state
                employeeCompanySqlRepository.Update(employeeCompany);

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
