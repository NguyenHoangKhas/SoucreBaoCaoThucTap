using _365EJSC.ERP.Application.Requests.University.Subject;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Subject
{
    /// <summary>
    /// Handler for <see cref="GetAllSubjectRequest"/>
    /// </summary>
    public class GetAllSubjectHandler : IRequestHandler<GetAllSubjectRequest, Result<IQueryable<Domain.Entities.University.Subject>>>
    {
        private readonly ISubjectSqlRepository subjectSqlRepository;

        public GetAllSubjectHandler(ISubjectSqlRepository subjectSqlRepository)
        {
            this.subjectSqlRepository = subjectSqlRepository;
        }

        public async Task<Result<IQueryable<Domain.Entities.University.Subject>>> Handle(GetAllSubjectRequest request, CancellationToken cancellationToken)
        {
            // Get all subjects
            IQueryable<Domain.Entities.University.Subject> subjects = subjectSqlRepository.FindAll();

            // Return success result with data
            return await Task.FromResult(Result<IQueryable<Domain.Entities.University.Subject>>.Ok(subjects));
        }
    }
}