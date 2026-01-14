using _365EJSC.ERP.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Domain.Entities.HRM
{
    public class EmployeeVerify : AggregateRoot<int>
    {

        /// <summary>
        /// Employee ID associated with the verification
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Path or name of the verification image
        /// </summary>
        public string? VerImage { get; set; }

        /// <summary>
        /// ID of the user who verified the employee
        /// </summary>
        public int UserIdVerify { get; set; }

        /// <summary>
        /// Date of verification (stored as an integer, possibly a timestamp)
        /// </summary>
        public int? VerCreatedDate { get; set; }

        /// <summary>
        /// Indicates if the verification is active (0 = inactive, 1 = active)
        /// </summary>
        public int IsActived { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Employee Employee { get; set; }
    }
}
