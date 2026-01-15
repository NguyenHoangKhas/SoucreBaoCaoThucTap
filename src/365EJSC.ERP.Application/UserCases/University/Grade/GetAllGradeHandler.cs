using _365EJSC.ERP.Application.Requests.University.Grade;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Grade
{
    /// <summary>
    /// Handler for <see cref="GetAllGradeRequest"/>
    /// </summary>
    public class GetAllGradeHandler : IRequestHandler<GetAllGradeRequest, Result<IQueryable<Domain.Entities.University.Grade>>>
    {
        private readonly IGradeSqlRepository gradeSqlRepository;

        public GetAllGradeHandler(IGradeSqlRepository gradeSqlRepository)
        {
            this.gradeSqlRepository = gradeSqlRepository;
        }

        public async Task<Result<IQueryable<Domain.Entities.University.Grade>>> Handle(GetAllGradeRequest request, CancellationToken cancellationToken)
        {
            // Get all grades
            IQueryable<Domain.Entities.University.Grade> grades = gradeSqlRepository.FindAll();

            // Return success result with data
            return await Task.FromResult(Result<IQueryable<Domain.Entities.University.Grade>>.Ok(grades));
        }
    }
}
