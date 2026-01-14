using _365EJSC.ERP.Contract.Filters;
using _365EJSC.ERP.Contract.Helpers;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Entities.HRM;
using MediatR;

public class GetAllAttendanceHisHandler
    : IRequestHandler<GetAllAttendanceHisRequest, Result<object>>
{
    private readonly IHrmAttendanceHisSqlRepository attendanceHisSqlRepository;

    public GetAllAttendanceHisHandler(IHrmAttendanceHisSqlRepository attendanceHisSqlRepository)
    {
        this.attendanceHisSqlRepository = attendanceHisSqlRepository;
    }

    public async Task<Result<object>> Handle(
        GetAllAttendanceHisRequest request,
        CancellationToken cancellationToken)
    {
        var fromCheckIn = request.FromCheckInTime ?? DateTime.MinValue;
        var toCheckIn = request.ToCheckInTime ?? DateTime.MaxValue;

        var expression = new FilterBuilder<AttendanceHis>()
    .AddEqualFilter(x => x.AttendanceId, request.AttendanceId)
    .AddEqualFilter(x => x.IsActived, request.IsActived)
    .AddCustomFilter(val =>
        x => x.CheckInTime >= fromCheckIn && x.CheckInTime <= toCheckIn,
        "dummy")
    .Build();


        var query = attendanceHisSqlRepository.FindAll(expression)
                                              .OrderByDescending(x => x.CheckInTime);

        var pagedResult = PaginationHelper.ApplyPaginationSkipTake(query, request);

        return Result<object>.Ok(pagedResult);
    }
}
