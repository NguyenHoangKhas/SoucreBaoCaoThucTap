using _365EJSC.ERP.Application.Requests.University.LecturerSubject;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.LecturerSubject
{
    /// <summary>
    /// Handler for <see cref="GetAllLecturerSubjectRequest"/>
    /// </summary>
    public class GetAllLecturerSubjectHandler : IRequestHandler<GetAllLecturerSubjectRequest, Result<IQueryable<Domain.Entities.University.LecturerSubject>>>
    {
        private readonly ILecturerSubjectSqlRepository lecturerSubjectSqlRepository;

        public GetAllLecturerSubjectHandler(ILecturerSubjectSqlRepository lecturerSubjectSqlRepository)
        {
            this.lecturerSubjectSqlRepository = lecturerSubjectSqlRepository;
        }

        public async Task<Result<IQueryable<Domain.Entities.University.LecturerSubject>>> Handle(GetAllLecturerSubjectRequest request, CancellationToken cancellationToken)
        {
            // Get all lecturer subjects
            IQueryable<Domain.Entities.University.LecturerSubject> lecturerSubjects = lecturerSubjectSqlRepository.FindAll();

            // Return success result with data
            return await Task.FromResult(Result<IQueryable<Domain.Entities.University.LecturerSubject>>.Ok(lecturerSubjects));
        }
    }
}