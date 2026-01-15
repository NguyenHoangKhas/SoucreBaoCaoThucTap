using _365EJSC.ERP.Application.Requests.University.Student;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Student
{
    /// <summary>
    /// Handler for <see cref="GetAllStudentRequest"/>
    /// </summary>
    public class GetAllStudentHandler : IRequestHandler<GetAllStudentRequest, Result<IQueryable<Domain.Entities.University.Student>>>
    {
        private readonly IStudentSqlRepository studentSqlRepository;

        public GetAllStudentHandler(IStudentSqlRepository studentSqlRepository)
        {
            this.studentSqlRepository = studentSqlRepository;
        }

        public async Task<Result<IQueryable<Domain.Entities.University.Student>>> Handle(GetAllStudentRequest request, CancellationToken cancellationToken)
        {
            // Get all students
            IQueryable<Domain.Entities.University.Student> students = studentSqlRepository.FindAll();

            // Return success result with data
            return await Task.FromResult(Result<IQueryable<Domain.Entities.University.Student>>.Ok(students));
        }
    }
}