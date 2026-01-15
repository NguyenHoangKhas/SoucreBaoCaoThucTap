using _365EJSC.ERP.Application.Requests.University.Subject;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Subject
{
    /// <summary>
    /// Handler for <see cref="GetDetailSubjectRequest"/>
    /// </summary>
    public class GetDetailSubjectHandler : IRequestHandler<GetDetailSubjectRequest, Result<Domain.Entities.University.Subject>>
    {
        private readonly ISubjectSqlRepository subjectSqlRepository;

        public GetDetailSubjectHandler(ISubjectSqlRepository subjectSqlRepository)
        {
            this.subjectSqlRepository = subjectSqlRepository;
        }

        public async Task<Result<Domain.Entities.University.Subject>> Handle(GetDetailSubjectRequest request, CancellationToken cancellationToken)
        {
            // Find subject by id
            Domain.Entities.University.Subject? subject = await subjectSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: false, cancellationToken);

            // Check if subject exists
            if (subject == null)
            {
                throw new Exception("Subject not found");
            }

            // Return success result with data
            return Result<Domain.Entities.University.Subject>.Ok(subject);
        }
    }
}