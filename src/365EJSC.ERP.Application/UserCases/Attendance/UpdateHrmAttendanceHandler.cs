using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Application.Validators.HRM.Attendance;
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
    /// Handler for <see cref="UpdateHrmAttendanceRequest"/>
    /// </summary>
    public class UpdateHrmAttendanceHandler : IRequestHandler<UpdateHrmAttendanceRequest, Result<object>>
    {
        private readonly IHrmAttendanceSqlRepository attendanceSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        /// <summary>
        /// Constructor of <see cref="UpdateHrmAttendanceHandler"/>, inject dependencies
        /// </summary>
        public UpdateHrmAttendanceHandler(IHrmAttendanceSqlRepository attendanceSqlRepository,
                                          ISqlUnitOfWork sqlUnitOfWork)
        {
            this.attendanceSqlRepository = attendanceSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        /// <summary>
        /// Handle <see cref="UpdateHrmAttendanceRequest"/>, update existing attendance record in DB
        /// </summary>
        public async Task<Result<object>> Handle(UpdateHrmAttendanceRequest request, CancellationToken cancellationToken)
        {
            // Validate
            UpdateHrmAttendanceValidator validator = new();
            validator.ValidateAndThrow(request);

            // Find existing entity
            Entities.Attendance? attendance = await attendanceSqlRepository.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (attendance is null)
                CustomException.ThrowNotFoundException(typeof(Entities.Attendance), MsgCode.ERR_ATTENDANCE_ID_NOT_FOUND);

            // Map update fields (preserve nulls)
            request.MapTo(attendance, true);

            // Begin transaction
            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // Mark entity updated
                attendanceSqlRepository.Update(attendance);

                // Save changes
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                // Commit
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
