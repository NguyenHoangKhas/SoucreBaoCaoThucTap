using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.Validators.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany
{
    /// <summary>
    /// Handler for <see cref="DeleteEmployeeCompanyRequest"/>
    /// </summary>
    public class DeleteEmployeeCompanyHandler : IRequestHandler<DeleteEmployeeCompanyRequest, Result<object>>
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
        /// Constructor of <see cref="DeleteEmployeeCompanyHandler"/>, inject needed dependency
        /// </summary>
        public DeleteEmployeeCompanyHandler(IEmployeeCompanySqlRepository employeeCompanySqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.employeeCompanySqlRepository = employeeCompanySqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        /// <summary>
        /// Handle <see cref="DeleteEmployeeCompanyRequest"/>, find existing <see cref="Entities.EmployeeCompany"/> based on id provided in <see cref="DeleteEmployeeCompanyRequest"/>,
        /// delete found <see cref="Entities.EmployeeCompany"/> and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>
        public async Task<Result<object>> Handle(DeleteEmployeeCompanyRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            DeleteEmployeeCompanyValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find EmployeeCompany based on id provided from database, if not found, throw not found exception.
            // Need tracking to delete EmployeeCompany.
            var employeeCompany = await employeeCompanySqlRepository.FindByIdAsync(request.Id, true, cancellationToken);
            if (employeeCompany is null)
                CustomException.ThrowNotFoundException(typeof(Entities.EmployeeCompany), MsgCode.ERR_EMPLOYEE_COMPANY_ID_NOT_FOUND);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                employeeCompanySqlRepository.Remove(employeeCompany!);

                // Save changes to database
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
