using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Application.Validators.HRM.Attendance;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.Attendance
{
    /// <summary>
    /// Handler for <see cref="CreateHrmAttendanceRequest"/>
    /// </summary>
    public class CreateHrmAttendanceHandler : IRequestHandler<CreateHrmAttendanceRequest, Result<object>>
    {
        private readonly IHrmAttendanceSqlRepository attendanceSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateHrmAttendanceHandler(IHrmAttendanceSqlRepository attendanceSqlRepository,
                                          ISqlUnitOfWork sqlUnitOfWork)
        {
            this.attendanceSqlRepository = attendanceSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateHrmAttendanceRequest request, CancellationToken cancellationToken)
        {
            // --- Validate request using FluentValidation ---
            var validator = new CreateHrmAttendanceValidator();
            try
            {
                validator.ValidateAndThrow(request);
            }
            catch (Exception ex)
            {
                // Nếu validate lỗi, ném CustomException để middleware xử lý JSON
                CustomException.ThrowValidationException(MsgCode.ERR_ATTENDANCE_INVALID, ex.Message);
            }

            // --- Map request to domain entity ---
            Entities.Attendance attendance = request.MapTo<Entities.Attendance>();

            // --- Optional: check trùng ngày điểm danh ---
            if (attendance.EmployeeId > 0 && attendance.WorkDate > 0)
            {
                var existing = await attendanceSqlRepository.GetByEmployeeAndDateAsync(attendance.EmployeeId, attendance.WorkDate);
                if (existing != null)
                {
                    CustomException.ThrowConflictException(MsgCode.ERR_CONFLICT, "Attendance for this employee and date already exists");
                }
            }


            // --- Begin transaction ---
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                // Add entity
                attendanceSqlRepository.Add(attendance);

                // Save changes
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Commit transaction
                transaction.Commit();

                return Result<Entities.Attendance>.Ok(attendance);
            }
            catch (Exception ex)
            {
                // Rollback if any error
                transaction.Rollback();

                // Ném lên middleware để trả JSON chuẩn
                throw;
            }
        }
    }
}
