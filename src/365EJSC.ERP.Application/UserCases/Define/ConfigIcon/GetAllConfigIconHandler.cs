using _365EJSC.ERP.Application.Requests.Define.ConfigIcon;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using MediatR;
using Entities = _365EJSC.ERP.Domain.Entities.Define;

namespace _365EJSC.ERP.Application.UserCases.Define.ConfigIcon
{
    /// <summary>
    ///  Handler for <see cref="GetAllConfigIconRequest"/>
    /// </summary>
    public class GetAllConfigIconHandler : IRequestHandler<GetAllConfigIconRequest, Result<IQueryable<Entities.ConfigIcon>>>
    {
        private readonly IConfigIconSqlRepository configIconSqlRepository;
        private readonly IFileService fileService;

        public GetAllConfigIconHandler(IConfigIconSqlRepository configIconSqlRepository, IFileService fileService)
        {
            this.configIconSqlRepository = configIconSqlRepository;
            this.fileService = fileService;
        }

        /// <summary>
        /// Handle <see cref="GetAllConfigIconRequest"/>, get all <see cref="Entities.ConfigIcon"/> base on data <see cref="GetAllConfigIconRequest"/>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<IQueryable<Entities.ConfigIcon>>> Handle(GetAllConfigIconRequest request, CancellationToken cancellationToken)
        {
            var result = configIconSqlRepository.FindAll().AsEnumerable().Select(i =>
                        {
                            i.IconUrl = fileService.GetFullPathFileServer(i.IconUrl);
                            return i;
                        }).OrderBy(x => x.Id).AsQueryable();
            return Task.FromResult(Result<IQueryable<Entities.ConfigIcon>>.Ok(result));
        }
    }
}
