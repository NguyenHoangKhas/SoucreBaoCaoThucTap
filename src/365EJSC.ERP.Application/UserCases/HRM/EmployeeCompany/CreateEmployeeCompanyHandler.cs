using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Application.Validators.HRM.EmployeeCompany;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using MediatR;
using System.Data;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeCompany
{
    /// <summary>
    /// Handler for <see cref="CreateEmployeeCompanyRequest"/>
    /// </summary>
    public class CreateEmployeeCompanyHandler : IRequestHandler<CreateEmployeeCompanyRequest, Result<object>>
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
        /// Constructor of <see cref="CreateEmployeeCompanyHandler"/>, inject needed dependency
        /// </summary>
        public CreateEmployeeCompanyHandler(IEmployeeCompanySqlRepository employeeCompanySqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.employeeCompanySqlRepository = employeeCompanySqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        /// <summary>
        /// Handle <see cref="CreateEmployeeCompanyRequest"/>, create new <see cref="Entities.EmployeeCompany"/> based on data from <see cref="CreateEmployeeCompanyRequest"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(CreateEmployeeCompanyRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            CreateEmployeeCompanyValidator validator = new();
            validator.ValidateAndThrow(request);

            // Check exist employee company
            var isExist = employeeCompanySqlRepository.FindAll(x => x.EmployeeId.Equals(request.EmployeeId) && x.CdId.Equals(request.CdId)).Any();
            if (isExist) return Result<object>.Ok();

            await employeeCompanySqlRepository.ValidateEmployeeCompany(request.EmployeeId, request.CdId);

            // Create new EmployeeCompany from request
            var employeeCompany = request.MapTo<Entities.EmployeeCompany>();

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Mark employeeCompany as Created state
                employeeCompanySqlRepository.Add(employeeCompany);

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
