using _365EJSC.ERP.Application.Requests.University.Grade;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Grade
{
    /// <summary>
    /// Handler for <see cref="GetDetailGradeRequest"/>
    /// </summary>
    public class GetDetailGradeHandler : IRequestHandler<GetDetailGradeRequest, Result<Domain.Entities.University.Grade>>
    {
        private readonly IGradeSqlRepository gradeSqlRepository;

        public GetDetailGradeHandler(IGradeSqlRepository gradeSqlRepository)
        {
            this.gradeSqlRepository = gradeSqlRepository;
        }

        public async Task<Result<Domain.Entities.University.Grade>> Handle(GetDetailGradeRequest request, CancellationToken cancellationToken)
        {
            // Find grade by id
            Domain.Entities.University.Grade? grade = await gradeSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: false, cancellationToken);

            // Check if grade exists
            if (grade == null)
            {
                throw new Exception("Grade not found");
            }

            // Return success result with data
            return Result<Domain.Entities.University.Grade>.Ok(grade);
        }
    }
}