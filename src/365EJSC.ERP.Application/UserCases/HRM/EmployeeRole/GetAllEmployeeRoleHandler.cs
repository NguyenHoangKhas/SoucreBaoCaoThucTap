using _365EJSC.ERP.Application.Requests.HRM.EmployeeRole;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using MediatR;
using Entities = _365EJSC.ERP.Domain.Entities.HRM;

namespace _365EJSC.ERP.Application.UserCases.HRM.EmployeeRole
{
    public class GetAllEmployeeRoleHandler : IRequestHandler<GetAllEmployeeRoleRequest, Result<IQueryable<Entities.EmployeeRole>>>
    {
        private readonly IEmployeeRoleSqlRepository employeeRoleSqlRepository;

        public GetAllEmployeeRoleHandler(IEmployeeRoleSqlRepository employeeRoleSqlRepository)
        {
            this.employeeRoleSqlRepository = employeeRoleSqlRepository;
        }

        public Task<Result<IQueryable<Entities.EmployeeRole>>> Handle(GetAllEmployeeRoleRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Result<IQueryable<Entities.EmployeeRole>>.Ok(employeeRoleSqlRepository.FindAll().OrderBy(x => x.EmpRoleName).AsQueryable()));
        }
    }
}
