using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;
using _365EJSC.ERP.Application.Validators.Define.WebLocalWardsV2;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using MediatR;
using Entity = _365EJSC.ERP.Domain.Entities.Define.WebLocalWardsV2;

namespace _365EJSC.ERP.Application.UserCases.Define.WebLocalWardsV2
{
    public class GetDetailWebLocalWardsV2Handler : IRequestHandler<GetDetailWebLocalWardsV2Request, Result<Entity>>
    {
        private readonly IWebLocalWardsV2SqlRepository webLocalWardsV2Repo;

        public GetDetailWebLocalWardsV2Handler(IWebLocalWardsV2SqlRepository webLocalWardsV2Repo)
        {
            this.webLocalWardsV2Repo = webLocalWardsV2Repo;
        }

        public async Task<Result<Entity>> Handle(GetDetailWebLocalWardsV2Request request, CancellationToken cancellationToken)
        {
            // Validate request
            var validator = new GetDetailWebLocalWardsV2Validator();
            validator.ValidateAndThrow(request);

            var entity = webLocalWardsV2Repo.FindAll(x => x.Id == request.Id)
                .Select(w => new Entity
                {
                    Id = w.Id,
                    Name = w.Name,
                    NameEn = w.NameEn,
                    FullName = w.FullName,
                    FullNameEn = w.FullNameEn,
                    Latitude = w.Latitude,
                    Longitude = w.Longitude,
                    WardPid = w.WardPid,
                    KeyLocalization = w.KeyLocalization,
                    ChildWards = w.ChildWards.Select(c => new Entity
                    {
                        Id = c.Id,
                        Name = c.Name,
                        FullName = c.FullName,
                        WardPid = c.WardPid
                    }).ToList()
                }).FirstOrDefault();

            if (entity == null)
                CustomException.ThrowNotFoundException(typeof(Entity), MsgCode.ERR_DEFINE_WEB_LOCAL_WARDS_V2_ID_NOT_FOUND);

            return Result<Entity>.Ok(entity);
        }
    }
}
