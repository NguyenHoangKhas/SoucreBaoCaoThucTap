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
    /// Handler for <see cref="UpdateHelpdeskContentRequest"/> 
    /// </summary>
    public class UpdateHelpdeskContentHandler : IRequestHandler<UpdateHelpdeskContentRequest, Result<object>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IHelpdeskContentSqlRepository helpdeskContentRepo;
        // Unit of work to handle transaction
        private readonly ISqlUnitOfWork unitOfWork;

        /// <summary>
        /// Constructor of <see cref="UpdateHelpdeskContentHandler"/>, inject needed dependency
        /// </summary>
        public UpdateHelpdeskContentHandler(IHelpdeskContentSqlRepository helpdeskContentRepo, ISqlUnitOfWork unitOfWork)
        {
           this.helpdeskContentRepo = helpdeskContentRepo;
           this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle <see cref="UpdateHelpdeskContentRequest"/>, Update the <see cref="Entity"/> base on data <see cref="UpdateHelpdeskContentRequest"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(UpdateHelpdeskContentRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            var validator = new UpdateHelpdeskContentValidator();
            validator.ValidateAndThrow(request);

            // Find HelpdeskContent from database, throw NotFoundException when not found
            var helpdeskContent = await helpdeskContentRepo.FindByIdAsync((int)request.Id, true, cancellationToken);
            if(helpdeskContent == null)
                CustomException.ThrowNotFoundException(typeof(Entity), MsgCode.ERR_DEFINE_HELPDESK_CONTENT_ID_NOT_FOUND);
            request.MapTo(helpdeskContent, true);

            // Begin transaction
            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked HelpdeskContent as Update state
                helpdeskContentRepo.Update(helpdeskContent);
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
