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
    /// <summary>
    ///  Handler for <see cref="CreateConfigIconRequest"/>/
    /// </summary>
    public class CreateConfigIconHandler : IRequestHandler<CreateConfigIconRequest, Result<object>>
    {
        private readonly IConfigIconSqlRepository configIconSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;
        private readonly IFileService fileService;

        public CreateConfigIconHandler(IConfigIconSqlRepository configIconSqlRepository, ISqlUnitOfWork unitOfWork, IFileService fileService)
        {
            this.configIconSqlRepository = configIconSqlRepository;
            this.sqlUnitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        /// <summary>
        /// Handle <see cref="CreateConfigIconRequest"/>, create new <see cref="Entities.ConfigIcon"/> base on data <see cref="CreateConfigIconRequest"/>
        /// and save to database
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="Result{TModel}"/> with success status</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<object>> Handle(CreateConfigIconRequest request, CancellationToken cancellationToken)
        {
            // Create validator and validate request
            CreateConfigIconValidator validator = new();
            validator.ValidateAndThrow(request);

            var existingConfigIcon = await configIconSqlRepository.IsExistAsync(i => i.Id.Equals(request.Id), cancellationToken);
            if (existingConfigIcon) CustomException.ThrowConflictException(MsgCode.ERR_KEY_CONFIG_ICON_EXISTED, ConfigIconConst.MSG_KEY_CONFIG_ICON_EXISTED);
            
            // Create new webLocal from request
            Entities.ConfigIcon? configIcon = request.MapTo<Entities.ConfigIcon>();
            
            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked configIcon as Created state
                configIconSqlRepository.Add(configIcon);

                // Save data to database
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Update configIcon url
                var uploadRequest = new UploadFileRequest
                {
                    Content = request.IconUrlBase64,
                    FileName = string.Format(Const.FILENAME_CONFIG_ICON, request.Id),
                    enumOptionPath = EnumOptionPath.ConfigIcon
                };
                configIcon.IconUrl = await fileService.UploadFileAsync(uploadRequest);
                configIconSqlRepository.Update(configIcon);

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
