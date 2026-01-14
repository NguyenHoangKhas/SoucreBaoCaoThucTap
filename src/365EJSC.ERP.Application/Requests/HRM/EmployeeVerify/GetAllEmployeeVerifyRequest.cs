using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Domain.DTOs.HRM;

namespace _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify
{
    /// <summary>
    /// Request to get all existed <see cref="EmployeeVerify"/> from database, can limit records or skip a number of records
    /// </summary>
    public record GetAllEmployeeVerifyRequest : IQuery<IQueryable<EmployeeVerifyDTOs>>
    {
        /// <summary>
        /// Request EmployeeId
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Request IsActived
        /// </summary>
        public int? IsActived { get; set; }
    }
}
