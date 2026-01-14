using _365EJSC.ERP.Application.Validators.Define.WebLocalWardsV2;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Enumerations;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.WebLocalWardsV2;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;

namespace _365EJSC.ERP.Application.UserCases.Define.WebLocalWardsV2
{
    /// <summary>
    /// Handler for <see cref="CreateWebLocalWardsV2Request"/> 
    /// </summary>
    public class CreateWebLocalWardsV2Handler : IRequestHandler<CreateWebLocalWardsV2Request, Result<object>>
    {
        // Repository handle data access of <see cref="Entity"/>>
        private readonly IWebLocalWardsV2SqlRepository webLocalWardsV2Repo;
        // Unit of work to handle transaction
        private readonly ISqlUnitOfWork unitOfWork;

        /// <summary>
        /// Constructor of <see cref="CreateWebLocalWardsV2Handler"/>, inject needed dependency
        /// </summary>
        public CreateWebLocalWardsV2Handler(IWebLocalWardsV2SqlRepository webLocalWardsV2Repo, ISqlUnitOfWork unitOfWork)
        {
           this.webLocalWardsV2Repo = webLocalWardsV2Repo;
           this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle <see cref="CreateWebLocalWardsV2Request"/>, Create the <see cref="Entity"/> base on data <see cref="CreateWebLocalWardsV2Request"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(CreateWebLocalWardsV2Request request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            var validator = new CreateWebLocalWardsV2Validator();
            validator.ValidateAndThrow(request);

            // Create new WebLocalWardsV2 from request
            var parentWard = request.MapTo<Entity>();

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                webLocalWardsV2Repo.Add(parentWard);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                if (request.ChildWards != null && request.ChildWards.Any())
                {
                    foreach (var childReq in request.ChildWards)
                    {
                        var childWard = childReq.MapTo<Entity>();
                        childWard.WardPid = parentWard.Id; 
                        webLocalWardsV2Repo.Add(childWard);
                    }
                    await unitOfWork.SaveChangesAsync(cancellationToken);
                }

                transaction.Commit();
                return Result<object>.Ok();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }
    }
}
