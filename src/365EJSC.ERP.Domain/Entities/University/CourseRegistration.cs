using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.University
{
    public class CourseRegistration : AggregateRoot<int>
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
        /// Registration status
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Registration date
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// Student info
        /// </summary>
        [JsonIgnore]
        public Student? StudentInfo { get; set; }

        /// <summary>
        /// Subject info
        /// </summary>
        [JsonIgnore]
        public Subject? SubjectInfo { get; set; }
    }
}
