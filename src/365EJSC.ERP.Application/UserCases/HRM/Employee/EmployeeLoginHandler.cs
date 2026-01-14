using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.Shared;
using MediatR;
using _365EJSC.ERP.Domain.DTOs.HRM;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Contract.Exceptions;
using System.Net;
using _365EJSC.ERP.Application.Validators.HRM.Employee;
using _365EJSC.ERP.Domain.Constants.HRM;
using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.UserCases.HRM.Employee
{
    public class EmployeeLoginHandler : IRequestHandler<EmployeeLoginRequest, Result<EmployeeLoginDTOs>>
    {
        private readonly IEmployeeSqlRepository employeeSqlRepository;
        private readonly IPasswordHasher passwordHasher;

        public EmployeeLoginHandler(IEmployeeSqlRepository employeeSqlRepository, IPasswordHasher passwordHasher)
        {
            this.employeeSqlRepository = employeeSqlRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<Result<EmployeeLoginDTOs>> Handle(EmployeeLoginRequest request, CancellationToken cancellationToken)
        {
            EmployeeLoginValidator validator = new();
            validator.ValidateAndThrow(request);

            var employee = await employeeSqlRepository.FindSingleAsync(c => c.EmpCode.Equals(request.EmpCode), cancellationToken: cancellationToken);
            if (employee == null) CustomException.ThrowNotFoundException(typeof(Domain.Entities.HRM.Employee), Contract.Enumerations.MsgCode.ERR_EMPLOYEE_ID_NOT_FOUND, EmployeeConst.MSG_EMPLOYEE_ID_NOT_FOUND);

            bool verified = passwordHasher.VerifyPassword(request.Password, employee.Password);

            if (!verified)
                CustomException.ThrowException((int)HttpStatusCode.Unauthorized, Contract.Enumerations.MsgCode.ERR_UNAUTHORIZED, "Username or Password is incorrect");

            return new EmployeeLoginDTOs
            {
                Id = employee.Id,
                FirstName = employee.EmpFirstName,
                LastName = employee.EmpLastName,
            };
        }
    }
}
