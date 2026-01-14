using _365EJSC.ERP.Application.Requests.HRM.AttendanceHis;
using _365EJSC.ERP.Application.Validators.HRM.AttendanceHis;
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
    public class DeleteHrmAttendanceHisHandler : IRequestHandler<DeleteHrmAttendanceHisRequest, Result<object>>
    {
        private readonly IHrmAttendanceHisSqlRepository attendanceHisSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;


        public DeleteHrmAttendanceHisHandler(IHrmAttendanceHisSqlRepository attendanceHisSqlRepository,
        ISqlUnitOfWork sqlUnitOfWork)
        {
            this.attendanceHisSqlRepository = attendanceHisSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }


        public async Task<Result<object>> Handle(DeleteHrmAttendanceHisRequest request, CancellationToken cancellationToken)
        {
            DeleteHrmAttendanceHisValidator validator = new();
            validator.ValidateAndThrow(request);


            Entities.AttendanceHis? entity = await attendanceHisSqlRepository.FindByIdAsync((int)request.Id!, true, cancellationToken);
            if (entity is null) CustomException.ThrowNotFoundException(typeof(Entities.AttendanceHis), MsgCode.ERR_ATTENDANCE_ID_NOT_FOUND);


            using IDbTransaction transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                entity.IsActived = 2;
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
