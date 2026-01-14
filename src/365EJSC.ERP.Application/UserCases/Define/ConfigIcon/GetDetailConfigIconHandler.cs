using _365EJSC.ERP.Application.Requests.Define.ConfigIcon;
using _365EJSC.ERP.Application.Validators.Define.ConfigIcon;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Domain.Constants.Define;
using MediatR;
using Entities = _365EJSC.ERP.Domain.Entities.Define;

namespace _365EJSC.ERP.Application.UserCases.Define.ConfigIcon
{
    /// <summary>
    /// Handler for <see cref="GetDetailConfigIconRequest"/>
    /// </summary>
    public class GetDetailConfigIconHandler : IRequestHandler<GetDetailConfigIconRequest, Result<Entities.ConfigIcon>>
    {
        private readonly IConfigIconSqlRepository configIconSqlRepository;
        private readonly IFileService fileService;

        public GetDetailConfigIconHandler(IConfigIconSqlRepository configIconSqlRepository, IFileService fileService)
        {
            this.configIconSqlRepository = configIconSqlRepository;
            this.fileService = fileService;
        }

        /// <summary>
        /// Handler for <see cref="GetDetailConfigIconRequest"/>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<Entities.ConfigIcon>> Handle(GetDetailConfigIconRequest request, CancellationToken cancellationToken)
        {
            GetDetailConfigIconValidator validator = new();
            validator.ValidateAndThrow(request);
            var result = await configIconSqlRepository.FindByIdAsync(request.Id, false, cancellationToken);
            if (result is null)
                CustomException.ThrowNotFoundException(typeof(Entities.ConfigIcon), MsgCode.ERR_KEY_CONFIG_ICON_NOT_FOUND, ConfigIconConst.MSG_KEY_CONFIG_ICON_NOT_FOUND);

            result!.IconUrl = fileService.GetFullPathFileServer(result.IconUrl);
            return result;
        }
    }
}
