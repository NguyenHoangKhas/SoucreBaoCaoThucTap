using System.Text.Json.Serialization;
using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.Employee
{
    /// <summary>
    /// Request reset password for <see cref="Employee"/>
    /// </summary>
    public class AdminResetEmployeePasswordRequest : ICommand
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
