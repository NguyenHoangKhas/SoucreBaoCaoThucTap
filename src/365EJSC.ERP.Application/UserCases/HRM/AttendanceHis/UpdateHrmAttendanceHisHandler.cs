using _365EJSC.ERP.Application.Requests.HRM.AttendanceHis;
using _365EJSC.ERP.Application.Validators.HRM.AttendanceHis;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Constants;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.DTOs;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.AttendanceHis
{
    public class UpdateHrmAttendanceHisHandler : IRequestHandler<UpdateHrmAttendanceHisRequest, Result<object>>
    {
        private readonly IHrmAttendanceHisSqlRepository attendanceHisSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public UpdateHrmAttendanceHisHandler(IHrmAttendanceHisSqlRepository attendanceHisSqlRepository,
                                             ISqlUnitOfWork sqlUnitOfWork)
        {
            this.attendanceHisSqlRepository = attendanceHisSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateHrmAttendanceHisRequest request, CancellationToken cancellationToken)
        {
            // Validate request
            var validator = new UpdateHrmAttendanceHisValidator();
            validator.ValidateAndThrow(request);

            // Find entity
            var entity = await attendanceHisSqlRepository.FindByIdAsync((int)request.Id!, true, cancellationToken);
            if (entity is null)
                CustomException.ThrowNotFoundException(typeof(Entities.AttendanceHis), MsgCode.ERR_ATTENDANCE_ID_NOT_FOUND);

            // Map request to entity
            request.MapTo(entity, true);

            // Begin transaction
            using var transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                attendanceHisSqlRepository.Update(entity);
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                transaction.Commit();
                return Result<object>.Ok();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
