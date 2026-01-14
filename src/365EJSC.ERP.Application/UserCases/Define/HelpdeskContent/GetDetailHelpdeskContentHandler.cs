using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Application.Requests.Define.HelpdeskContent;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.HelpdeskContent;

namespace _365EJSC.ERP.Application.UserCases.Define.HelpdeskContent
{
    /// <summary>
    /// Handler for <see cref="GetDetailHelpdeskContentRequest"/>/ 
    /// </summary>
    public class GetDetailHelpdeskContentHandler : IRequestHandler<GetDetailHelpdeskContentRequest, Result<Entity>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IHelpdeskContentSqlRepository helpdeskContentRepo;

        /// <summary>
        /// Constructor of <see cref="GetDetailHelpdeskContentHandler"/>, inject needed dependency
        /// </summary>
        public GetDetailHelpdeskContentHandler(IHelpdeskContentSqlRepository helpdeskContentRepo)
        {
           this.helpdeskContentRepo = helpdeskContentRepo;
        }

        /// <summary>
        /// Handle <see cref="GetDetailHelpdeskContentRequest"/>, GetDetail the <see cref="Entity"/> from database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with founded <see cref="Entity"/></returns>
        public async Task<Result<Entity>> Handle(GetDetailHelpdeskContentRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            var validator = new GetDetailHelpdeskContentValidator();
            validator.ValidateAndThrow(request);

            // Find HelpdeskContent from database, throw NotFoundException when not found
            var helpdeskContent = helpdeskContentRepo.FindAll(x => x.Id.Equals(request.Id)).FirstOrDefault();
            if(helpdeskContent == null)
            {
                CustomException.ThrowNotFoundException(typeof(Entity), MsgCode.ERR_DEFINE_HELPDESK_CONTENT_ID_NOT_FOUND);
            }
            return helpdeskContent;
        }
    }
}
