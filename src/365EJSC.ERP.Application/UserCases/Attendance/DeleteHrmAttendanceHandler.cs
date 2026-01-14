using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Application.Validators.HRM.Attendance;
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
    /// Handler for <see cref="DeleteHrmAttendanceRequest"/>
    /// </summary>
    public class DeleteHrmAttendanceHandler : IRequestHandler<DeleteHrmAttendanceRequest, Result<object>>
    {
        private readonly IHrmAttendanceSqlRepository attendanceSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        /// <summary>
        /// Constructor injects dependencies for <see cref="DeleteHrmAttendanceHandler"/>
        /// </summary>
        public DeleteHrmAttendanceHandler(IHrmAttendanceSqlRepository attendanceSqlRepository,
                                          ISqlUnitOfWork sqlUnitOfWork)
        {
            this.attendanceSqlRepository = attendanceSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        /// <summary>
        /// Handle deletion of an existing <see cref="HrmAttendance"/> record.
        /// </summary>
        public async Task<Result<object>> Handle(DeleteHrmAttendanceRequest request, CancellationToken cancellationToken)
        {
            // Validate request
            DeleteHrmAttendanceValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find attendance by Id
            Entities.Attendance? attendance = await attendanceSqlRepository.FindByIdAsync((int)request.Id!, true, cancellationToken);
            if (attendance is null)
                CustomException.ThrowNotFoundException(typeof(Entities.Attendance), MsgCode.ERR_ATTENDANCE_ID_NOT_FOUND);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Hard delete (remove)
                attendanceSqlRepository.Remove(attendance);

                // Save changes
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                transaction.Commit();
                return Result<object>.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
