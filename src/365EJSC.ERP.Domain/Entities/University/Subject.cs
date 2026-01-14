using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.University
{
    public class Subject : AggregateRoot<int>
    {
        /// <summary>
        /// Subject code
        /// </summary>
        public string SubjectCode { get; set; }

        /// <summary>
        /// Subject name
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Number of credits
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// Description of subject
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Prerequisite subject id
        /// </summary>
        public int? PrerequisiteId { get; set; }

        /// <summary>
        /// Prerequisite subject info
        /// </summary>
        [JsonIgnore]
        public Subject? PrerequisiteSubject { get; set; }

        /// <summary>
        /// Subjects that require this as prerequisite
        /// </summary>
        [JsonIgnore]
        public List<Subject>? DependentSubjects { get; set; }

        /// <summary>
        /// Registrations of this subject
        /// </summary>
        [JsonIgnore]
        public List<CourseRegistration>? CourseRegistrations { get; set; }

        /// <summary>
        /// Lecturer assignments
        /// </summary>
        [JsonIgnore]
        public List<LecturerSubject>? LecturerSubjects { get; set; }

        /// <summary>
        /// Grades of students for this subject
        /// </summary>
        [JsonIgnore]
        public List<Grade>? Grades { get; set; }
    }
}
