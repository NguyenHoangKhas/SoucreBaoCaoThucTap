using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Filters;
using _365EJSC.ERP.Contract.Helpers;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using MediatR;
using EntitiesHRM = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.Attendance
{
    public class GetAllAttendanceHandler : IRequestHandler<GetAllAttendanceRequest, Result<object>>
    {
        private readonly IHrmAttendanceSqlRepository attendanceSqlRepository;

        public GetAllAttendanceHandler(IHrmAttendanceSqlRepository attendanceSqlRepository)
        {
            this.attendanceSqlRepository = attendanceSqlRepository;
        }

        public Task<Result<object>> Handle(GetAllAttendanceRequest request, CancellationToken cancellationToken)
        {
            // Chọn giá trị mặc định nếu null: min = 0, max = int.MaxValue
            int minWorking = request.MinWorkingMinutes.GetValueOrDefault(0);
            int maxWorking = request.MaxWorkingMinutes.GetValueOrDefault(int.MaxValue);

            var expression = new FilterBuilder<EntitiesHRM.Attendance>()
                .AddEqualFilter(x => x.EmployeeId, request.EmployeeId)
                .AddEqualFilter(x => x.WorkDate, request.WorkDate)
                .AddEqualFilter(x => x.AttendanceStatus, request.AttendanceStatus)
                .AddRangeFilter(x => x.TotalWorkingMinutes ?? 0, minWorking, maxWorking) // Chuyển nullable sang int
                .Build();

            var result = attendanceSqlRepository.FindAll(expression)
                                               .OrderByDescending(x => x.WorkDate);

            return Task.FromResult<Result<object>>(PaginationHelper.ApplyPaginationSkipTake(result, request));
        }
    }
}
