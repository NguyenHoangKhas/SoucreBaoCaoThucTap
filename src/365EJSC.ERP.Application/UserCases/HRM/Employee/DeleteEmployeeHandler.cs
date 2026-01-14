using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.Employee
{
    /// <summary>
    /// Handler for <see cref="DeleteEmployeeRequest"/>
    /// </summary>
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, Result<object>>
    {
        /// <summary>
        /// Repository handle data access of <see cref="Employee"/>
        /// </summary>
        private readonly IEmployeeSqlRepository EmployeeSqlRepository;

        /// <summary>
        /// Unit of work to handle transaction
        /// </summary>
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        /// <summary>
        /// Constructor of <see cref="DeleteEmployeeHandler"/>, inject needed dependency
        /// </summary>
        public DeleteEmployeeHandler(IEmployeeSqlRepository EmployeeSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.EmployeeSqlRepository = EmployeeSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        /// <summary>
        /// Handle <see cref="DeleteEmployeeRequest"/>, find existing <see cref="Employee"/> based on id provided in <see cref="DeleteEmployeeRequest"/>,
        /// delete the found <see cref="Employee"/> and save to the database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>
        public async Task<Result<object>> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            DeleteEmployeeValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find Training Major based on id provided from database, if Training Major was not found, throw not found exception.
            // Need tracking to delete Training Major.
            Entities.Employee? employee = await EmployeeSqlRepository.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (employee is null) CustomException.ThrowNotFoundException(typeof(Entities.Employee), MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND);
          
            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                employee.IsActived = 2;
                EmployeeSqlRepository.Update(employee);

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
