using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.University
{
    public class Lecturer : AggregateRoot<int>
    {
        /// <summary>
        /// Lecturer code
        /// </summary>
        public string LecturerCode { get; set; }

        /// <summary>
        /// Full name of lecturer
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Academic degree
        /// </summary>
        public string? Degree { get; set; }

        /// <summary>
        /// Linked user account id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User info
        /// </summary>
        [JsonIgnore]
        public User? UserInfo { get; set; }

        /// <summary>
        /// Subjects assigned to lecturer
        /// </summary>
        [JsonIgnore]
        public List<LecturerSubject>? LecturerSubjects { get; set; }
    }
}
