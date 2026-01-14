using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify
{
    /// <summary>
    /// Request to create a TrainingMajor, contains name
    /// </summary>
    public record CreateEmployeeVerifyRequest : ICommand
    {

        /// <summary>
        /// Request Employee ID associated with the verification
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Request Path or name of the verification image
        /// </summary>
        public string? VerImageBase64 { get; set; }

        /// <summary>
        /// Request ID of the user who verified the employee
        /// </summary>
        public int? UserIdVerify { get; set; }

        /// <summary>
        /// Request Date of verification (stored as an integer, possibly a timestamp)
        /// </summary>
        [JsonIgnore]
        public int? VerCreatedDate { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();

        /// <summary>
        /// Request Indicates if the verification is active (0 = inactive, 1 = active)
        /// </summary>
        public int? IsActived { get; set; }
    }
}
