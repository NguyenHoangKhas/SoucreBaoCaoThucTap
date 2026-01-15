using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;
using _365EJSC.ERP.Domain.Entities.HRM;
using System.Threading.Tasks;

namespace _365EJSC.ERP.Domain.Entities.University
{
    public class User : AggregateRoot<int>
    {
        /// <summary>
        /// Username for login
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password hash (encrypted)
        /// </summary>
        [JsonIgnore]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Full name of the user
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// System role (Admin, Lecturer, Student, Manager, etc.)
        /// </summary>
        public string? Role { get; set; }


        /// <summary>
        /// Student object if user is a student
        /// </summary>
        [JsonIgnore]
        public Student? StudentInfo { get; set; }

        /// <summary>
        /// Lecturer object if user is a lecturer
        /// </summary>
        [JsonIgnore]
        public Lecturer? LecturerInfo { get; set; }
    }
}
