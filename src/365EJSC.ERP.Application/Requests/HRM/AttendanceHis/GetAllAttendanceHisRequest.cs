using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Entities.HRM;
using MediatR;

public class GetAllAttendanceHisRequest
    : PaginationOptionalQuery, IRequest<Result<object>>
{
    public int? AttendanceId { get; set; }
    public DateTime? FromCheckInTime { get; set; }
    public DateTime? ToCheckInTime { get; set; }
    public int? IsActived { get; set; }
}
