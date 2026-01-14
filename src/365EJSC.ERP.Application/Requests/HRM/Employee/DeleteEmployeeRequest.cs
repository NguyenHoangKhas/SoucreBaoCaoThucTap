using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.HRM.Employee
{
    /// <summary>
    /// Request to delete a Employee by its ID
    /// </summary>
    public record DeleteEmployeeRequest : ICommand
    {
        /// <summary>
        /// ID of the ward to be deleted
        /// </summary>
        public int? Id { get; set; }
    }
}
