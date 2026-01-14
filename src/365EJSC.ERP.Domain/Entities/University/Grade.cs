using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.University
{
    public class Grade : AggregateRoot<int>
    {
        /// <summary>
        /// Student id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Subject id
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Semester
        /// </summary>
        public string? Semester { get; set; }

        /// <summary>
        /// Academic year
        /// </summary>
        public string? AcademicYear { get; set; }

        /// <summary>
        /// Process score
        /// </summary>
        public decimal? ProcessScore { get; set; }

        /// <summary>
        /// Midterm score
        /// </summary>
        public decimal? MidtermScore { get; set; }

        /// <summary>
        /// Final exam score
        /// </summary>
        public decimal? FinalScore { get; set; }

        /// <summary>
        /// Total score
        /// </summary>
        public decimal? TotalScore { get; set; }

        /// <summary>
        /// Letter grade (A, B, C…)
        /// </summary>
        public string? LetterGrade { get; set; }

        /// <summary>
        /// Student navigation
        /// </summary>
        [JsonIgnore]
        public Student? StudentInfo { get; set; }

        /// <summary>
        /// Subject navigation
        /// </summary>
        [JsonIgnore]
        public Subject? SubjectInfo { get; set; }
    }
}
