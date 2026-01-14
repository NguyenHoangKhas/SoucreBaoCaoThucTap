using _365EJSC.ERP.Application.Requests.Define.ConfigIcon;
using _365EJSC.ERP.Application.Validators.Define.ConfigIcon;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Constants;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.DTOs;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Domain.Constants.Define;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.Define; 

namespace _365EJSC.ERP.Application.UserCases.Define.ConfigIcon
{
    public class UpdateConfigIconHandler : IRequestHandler<UpdateConfigIconRequest, Result<object>>
    {
        private readonly IConfigIconSqlRepository configIconSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;
        private readonly IFileService fileService;

        public UpdateConfigIconHandler(IConfigIconSqlRepository configIconSqlRepository, ISqlUnitOfWork sqlUnitOfWork, IFileService fileService)
        {
            this.configIconSqlRepository = configIconSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
            this.fileService = fileService;
        }

        public async Task<Result<object>> Handle(UpdateConfigIconRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            UpdateConfigIconValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find ConfigIcon base on id provided from database, if configIcon was not found, throw not found exception.
            // Need tracking to update configIcon.
            var configIcon = await configIconSqlRepository.FindByIdAsync(request.Id, true, cancellationToken);
            if (configIcon is null)
                CustomException.ThrowNotFoundException(typeof(Entities.ConfigIcon), MsgCode.ERR_KEY_CONFIG_ICON_NOT_FOUND, ConfigIconConst.MSG_KEY_CONFIG_ICON_NOT_FOUND);

            // Update ConfigIcon base on data provided in UpdateConfigIconRequest request.
            // Keep Local original data if request fields is null
            request.MapTo(configIcon, true);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Checking UrlBase64 is not null. Override icon if true
                if (request.IconUrlBase64 is not null)
                {
                    var uploadRequest = new UploadFileRequest
                    {
                        Content = request.IconUrlBase64,
                        FileName = string.Format(Const.FILENAME_CONFIG_ICON, request.Id),
                        enumOptionPath = EnumOptionPath.ConfigIcon
                    };
                    configIcon!.IconUrl = await fileService.UploadFileAsync(uploadRequest);
                }

                // Mark configIcon as Updated state
                configIconSqlRepository.Update(configIcon!);

                // Save configIcon to database
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
