using _365EJSC.ERP.Application.Requests.University.Student;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;

namespace _365EJSC.ERP.Application.UserCases.University.Student
{
    /// <summary>
    /// Handler for <see cref="GetDetailStudentRequest"/>
    /// </summary>
    public class GetDetailStudentHandler : IRequestHandler<GetDetailStudentRequest, Result<Domain.Entities.University.Student>>
    {
        private readonly IStudentSqlRepository studentSqlRepository;

        public GetDetailStudentHandler(IStudentSqlRepository studentSqlRepository)
        {
            this.studentSqlRepository = studentSqlRepository;
        }

        public async Task<Result<Domain.Entities.University.Student>> Handle(GetDetailStudentRequest request, CancellationToken cancellationToken)
        {
            // Find student by id
            Domain.Entities.University.Student? student = await studentSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: false, cancellationToken);

            // Check if student exists
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            // Return success result with data
            return Result<Domain.Entities.University.Student>.Ok(student);
        }
    }
}