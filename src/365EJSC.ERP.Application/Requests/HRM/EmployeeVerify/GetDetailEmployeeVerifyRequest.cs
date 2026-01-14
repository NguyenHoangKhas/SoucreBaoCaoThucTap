using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Domain.DTOs.HRM;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify
{
    /// <summary>
    /// Request to get existed <see cref="EmployeeVerify"/> by id from database
    /// </summary>
    public record GetDetailEmployeeVerifyRequest : IQuery<EmployeeVerifyDTOs>
    {
        [JsonIgnore]
        public int? Id { get; set; }
    }
}
