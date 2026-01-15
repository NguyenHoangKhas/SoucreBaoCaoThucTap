using _365EJSC.ERP.Application.Requests.University.Grade;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using MediatR;
using System.Data;

namespace _365EJSC.ERP.Application.UserCases.University.Grade
{
    /// <summary>
    /// Handler for <see cref="UpdateGradeRequest"/>
    /// </summary>
    public class UpdateGradeHandler : IRequestHandler<UpdateGradeRequest, Result<object>>
    {
        private readonly IGradeSqlRepository gradeSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public UpdateGradeHandler(IGradeSqlRepository gradeSqlRepository, ISqlUnitOfWork sqlUnitOfWork)
        {
            this.gradeSqlRepository = gradeSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateGradeRequest request, CancellationToken cancellationToken)
        {
            // Find existing grade by id
            Domain.Entities.University.Grade? grade = await gradeSqlRepository.FindByIdAsync(request.Id!.Value, isTracking: true, cancellationToken);

            // Check if grade exists
            if (grade == null)
            {
                throw new Exception("Grade not found");
            }

            // Update grade properties from request
            if (request.Semester != null)
                grade.Semester = request.Semester;
            if (request.AcademicYear != null)
                grade.AcademicYear = request.AcademicYear;
            if (request.ProcessScore.HasValue)
                grade.ProcessScore = request.ProcessScore;
            if (request.MidtermScore.HasValue)
                grade.MidtermScore = request.MidtermScore;
            if (request.FinalScore.HasValue)
                grade.FinalScore = request.FinalScore;
            if (request.TotalScore.HasValue)
                grade.TotalScore = request.TotalScore;
            if (request.LetterGrade != null)
                grade.LetterGrade = request.LetterGrade;

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Marked grade as Updated state
                gradeSqlRepository.Update(grade);

                // Save data to database
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Commit transaction
                transaction.Commit();

                // Return success result
                return Result<object>.Ok();
            }
            catch (Exception)
            {
                // Rollback transaction if any exception happened, then throw exception
                transaction.Rollback();
                throw;
            }
        }
    }
}