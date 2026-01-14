using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.University
{
    public class Class : AggregateRoot<int>
    {
        /// <summary>
        /// Class code
        /// </summary>
        public string ClassCode { get; set; }

        /// <summary>
        /// Class name
        /// </summary>
        public string? ClassName { get; set; }

        /// <summary>
        /// Academic year
        /// </summary>
        public string? AcademicYear { get; set; }

        /// <summary>
        /// Department or faculty
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Advisor lecturer id
        /// </summary>
        public int? AdvisorId { get; set; }

        /// <summary>
        /// Advisor information (Lecturer)
        /// </summary>
        [JsonIgnore]
        public Lecturer? AdvisorInfo { get; set; }

        /// <summary>
        /// List of students in this class
        /// </summary>
        [JsonIgnore]
        public List<Student>? Students { get; set; }
    }
}
