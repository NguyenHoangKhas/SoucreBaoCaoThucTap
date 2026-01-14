using _365EJSC.ERP.Application.Requests.HRM.AttendanceHis;
using _365EJSC.ERP.Application.Validators.HRM.AttendanceHis;
using _365EJSC.ERP.Contract.Abstractions;
using _365EJSC.ERP.Contract.Constants;
using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.DTOs;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Contract.Exceptions;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using MediatR;
using System.Data;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.AttendanceHis
{
    public class CreateHrmAttendanceHisHandler : IRequestHandler<CreateHrmAttendanceHisRequest, Result<object>>
    {
        private readonly IHrmAttendanceHisSqlRepository attendanceHisSqlRepository;
        private readonly ISqlUnitOfWork sqlUnitOfWork;

        public CreateHrmAttendanceHisHandler(IHrmAttendanceHisSqlRepository attendanceHisSqlRepository,
                                             ISqlUnitOfWork sqlUnitOfWork)
        {
            this.attendanceHisSqlRepository = attendanceHisSqlRepository;
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(CreateHrmAttendanceHisRequest request, CancellationToken cancellationToken)
        {
            // Validate request
            var validator = new CreateHrmAttendanceHisValidator();
            validator.ValidateAndThrow(request);

            // Map request to entity
            var entity = request.MapTo<Entities.AttendanceHis>();

            // Begin transaction
            using var transaction = await sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                attendanceHisSqlRepository.Add(entity); 
                await sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                transaction.Commit();
                return Result<Entities.AttendanceHis>.Ok(entity);
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
