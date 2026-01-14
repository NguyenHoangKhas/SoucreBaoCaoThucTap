using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.HRM.AttendanceHis
{
    public record DeleteHrmAttendanceHisRequest : ICommand
    {
        public int? Id { get; set; }
    }
}
