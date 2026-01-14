using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify
{
    /// <summary>
    /// Request to delete a EmployeeVerify by its ID
    /// </summary>
    public record DeleteEmployeeVerifyRequest : ICommand
    {
        /// <summary>
        /// ID of the ward to be deleted
        /// </summary>
        [JsonIgnore]
        public int? Id { get; set; }
    }
}
