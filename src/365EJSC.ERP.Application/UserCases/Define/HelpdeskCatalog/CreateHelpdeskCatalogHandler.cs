using _365EJSC.ERP.Application.Requests.Define.HelpdeskCatalog;
using _365EJSC.ERP.Application.Validators.Define.HelpdeskCatalog;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Enumerations;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskCatalog;

namespace _365EJSC.ERP.Application.UserCases.Define.HelpdeskCatalog
{
    /// <summary>
    /// Handler for <see cref="CreateHelpdeskCatalogRequest"/> 
    /// </summary>
    public class CreateHelpdeskCatalogHandler : IRequestHandler<CreateHelpdeskCatalogRequest, Result<object>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IHelpdeskCatalogSqlRepository helpdeskCatalogRepo;
        // Unit of work to handle transaction
        private readonly ISqlUnitOfWork unitOfWork;

        /// <summary>
        /// Constructor of <see cref="CreateHelpdeskCatalogHandler"/>, inject needed dependency
        /// </summary>
        public CreateHelpdeskCatalogHandler(IHelpdeskCatalogSqlRepository helpdeskCatalogRepo, ISqlUnitOfWork unitOfWork)
        {
           this.helpdeskCatalogRepo = helpdeskCatalogRepo;
           this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle <see cref="CreateHelpdeskCatalogRequest"/>, Create the <see cref="Entity"/> base on data <see cref="CreateHelpdeskCatalogRequest"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(CreateHelpdeskCatalogRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            var validator = new CreateHelpdeskCatalogValidator();
            validator.ValidateAndThrow(request);

            // Create new HelpdeskCatalog from request
            var helpdeskCatalog = request.MapTo<Entity>();

            // Begin transaction
            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked HelpdeskCatalog as Create state
                helpdeskCatalogRepo.Add(helpdeskCatalog);
                // Save data to database
                await unitOfWork.SaveChangesAsync(cancellationToken);

                 // Commit transaction
                 transaction.Commit();
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
