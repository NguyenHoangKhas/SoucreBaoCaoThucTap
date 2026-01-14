using System.Text.Json.Serialization;
using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.Employee
{
    /// <summary>
    /// Request for change password for <see cref="Employee"/>
    /// </summary>
    public class EmployeeChangePasswordRequest : ICommand
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
