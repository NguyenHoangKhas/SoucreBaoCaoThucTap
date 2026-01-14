using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.University
{
    public class LecturerSubject : AggregateRoot<int>
    {
        /// <summary>
        /// Lecturer id
        /// </summary>
        public int LecturerId { get; set; }

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
        /// Lecturer navigation
        /// </summary>
        [JsonIgnore]
        public Lecturer? LecturerInfo { get; set; }

        /// <summary>
        /// Subject navigation
        /// </summary>
        [JsonIgnore]
        public Subject? SubjectInfo { get; set; }
    }
}
