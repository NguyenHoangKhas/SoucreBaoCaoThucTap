using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Grade
{
    public record CreateGradeRequest : ICommand
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string? Semester { get; set; }
        public string? AcademicYear { get; set; }
        public decimal? ProcessScore { get; set; }
        public decimal? MidtermScore { get; set; }
        public decimal? FinalScore { get; set; }
        public decimal? TotalScore { get; set; }
        public string? LetterGrade { get; set; }
    }
}