using _365EJSC.ERP.Application.Requests.University.LecturerSubject;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.LecturerSubject
{
    /// <summary>
    /// Handler for <see cref="GetDetailLecturerSubjectRequest"/>
    /// </summary>
    public class GetDetailLecturerSubjectHandler : IRequestHandler<GetDetailLecturerSubjectRequest, Result<Domain.Entities.University.LecturerSubject>>
    {
        private readonly ILecturerSubjectSqlRepository lecturerSubjectSqlRepository;

        public GetDetailLecturerSubjectHandler(ILecturerSubjectSqlRepository lecturerSubjectSqlRepository)
        {
            this.lecturerSubjectSqlRepository = lecturerSubjectSqlRepository;
        }

        public async Task<Result<Domain.Entities.University.LecturerSubject>> Handle(GetDetailLecturerSubjectRequest request, CancellationToken cancellationToken)
        {
            // Find lecturer subject by id
            Domain.Entities.University.LecturerSubject? lecturerSubject = await lecturerSubjectSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: false, cancellationToken);

            // Check if lecturer subject exists
            if (lecturerSubject == null)
            {
                throw new Exception("Lecturer Subject not found");
            }

            // Return success result with data
            return Result<Domain.Entities.University.LecturerSubject>.Ok(lecturerSubject);
        }
    }
}