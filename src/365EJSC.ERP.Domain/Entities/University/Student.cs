using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.University
{
    public class Student : AggregateRoot<int>
    {
        /// <summary>
        /// Foreign key reference to User
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Student Code
        /// </summary>
        public string StudentCode { get; set; }

        /// <summary>
        /// Full name of student
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Class Id reference
        /// </summary>
        public int? ClassId { get; set; }

        /// <summary>
        /// User info associated with this student
        /// </summary>
        [JsonIgnore]
        public User? UserInfo { get; set; }

        /// <summary>
        /// Class info
        /// </summary>
        [JsonIgnore]
        public Class? ClassInfo { get; set; }

        /// <summary>
        /// List of grades
        /// </summary>
        [JsonIgnore]
        public List<Grade>? Grades { get; set; }

        /// <summary>
        /// Course registrations
        /// </summary>
        [JsonIgnore]
        public List<CourseRegistration>? CourseRegistrations { get; set; }
    }
}
