using _365EJSC.ERP.Application.Requests.University.Lecturer;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Lecturer
{
    /// <summary>
    /// Handler for <see cref="GetAllLecturerRequest"/>
    /// </summary>
    public class GetAllLecturerHandler : IRequestHandler<GetAllLecturerRequest, Result<IQueryable<Domain.Entities.University.Lecturer>>>
    {
        private readonly ILecturerSqlRepository lecturerSqlRepository;

        public GetAllLecturerHandler(ILecturerSqlRepository lecturerSqlRepository)
        {
            this.lecturerSqlRepository = lecturerSqlRepository;
        }

        public async Task<Result<IQueryable<Domain.Entities.University.Lecturer>>> Handle(GetAllLecturerRequest request, CancellationToken cancellationToken)
        {
            // Get all lecturers
            IQueryable<Domain.Entities.University.Lecturer> lecturers = lecturerSqlRepository.FindAll();

            // Return success result with data
            return await Task.FromResult(Result<IQueryable<Domain.Entities.University.Lecturer>>.Ok(lecturers));
        }
    }
}