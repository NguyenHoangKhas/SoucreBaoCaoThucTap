using _365EJSC.ERP.Application.Requests.Define.HelpdeskContent;
using _365EJSC.ERP.Application.Validators.Define.HelpdeskContent;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Enumerations;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskContent;

namespace _365EJSC.ERP.Application.UserCases.Define.HelpdeskContent
{
    /// <summary>
    /// Handler for <see cref="CreateHelpdeskContentRequest"/> 
    /// </summary>
    public class CreateHelpdeskContentHandler : IRequestHandler<CreateHelpdeskContentRequest, Result<object>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IHelpdeskContentSqlRepository helpdeskContentRepo;
        // Unit of work to handle transaction
        private readonly ISqlUnitOfWork unitOfWork;

        /// <summary>
        /// Constructor of <see cref="CreateHelpdeskContentHandler"/>, inject needed dependency
        /// </summary>
        public CreateHelpdeskContentHandler(IHelpdeskContentSqlRepository helpdeskContentRepo, ISqlUnitOfWork unitOfWork)
        {
           this.helpdeskContentRepo = helpdeskContentRepo;
           this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle <see cref="CreateHelpdeskContentRequest"/>, Create the <see cref="Entity"/> base on data <see cref="CreateHelpdeskContentRequest"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(CreateHelpdeskContentRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            var validator = new CreateHelpdeskContentValidator();
            validator.ValidateAndThrow(request);

            // Create new HelpdeskContent from request
            var helpdeskContent = request.MapTo<Entity>();

            // Begin transaction
            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked HelpdeskContent as Create state
                helpdeskContentRepo.Add(helpdeskContent);
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
