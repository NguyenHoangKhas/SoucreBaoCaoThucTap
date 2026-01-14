using _365EJSC.ERP.Application.Requests.HRM.Employee;
using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Infrastructure.Abstractions;
using _365EJSC.ERP.Infrastructure.DTOs;
using _365EJSC.ERP.Infrastructure.DTOs.Auth;
using _365EJSC.ERP.Presentation.Abstractions;
using _365EJSC.ERP.Presentation.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365EJSC.ERP.Presentation.Controllers.v1.HRM
{
    /// <summary>
    /// Controller version 1 for Employee apis
    /// </summary>
    [ApiVersion(1)]
    [Route(RouteConstant.API_PREFIX + RouteConstant.EMPLOYEE_ROUTE)]
    public class EmployeeController : ApiController
    {
        private readonly IJwtUtils jwtUtils;
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator, IJwtUtils jwtUtils)
        {
            this.mediator = mediator;
            this.jwtUtils = jwtUtils;
        }

        /// <summary>
        /// Api version 1 for create Employee
        /// </summary>
        /// <param name="request">Request to create Employee</param>
        /// <returns>Action result</returns>
        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> CreateV1(CreateEmployeeRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for update Employee
        /// </summary>
        /// <param name="id">Id of Employee need to be updated</param>
        /// <param name="request">Request body contains content to update</param>
        /// <returns></returns>
        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateV1(int id, [FromBody] UpdateEmployeeRequest request)
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for change employee password
        /// </summary>
        /// <param name="id">Id of employee need to be changed password</param>
        /// <param name="request">Request body contains content to update</param>
        /// <returns></returns>
        [MapToApiVersion(1)]
        [HttpPut("ChangePassword/{id}")]
        public async Task<IActionResult> ChangePasswordV1(int id, [FromBody] EmployeeChangePasswordRequest request)
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for change employee password
        /// </summary>
        /// <param name="id">Id of employee need to be changed password</param>
        /// <param name="request">Request body contains content to update</param>
        /// <returns></returns>
        [MapToApiVersion(1)]
        [HttpPut("ResetPassword/{id}")]
        public async Task<IActionResult> ResetPasswordV1(int id)
        {
            var result = await mediator.Send(new AdminResetEmployeePasswordRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for delete Employee
        /// </summary>
        /// <param name="id">id of Employee</param>
        /// <returns>Action result</returns>
        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteV1(int id)
        {
            var command = new DeleteEmployeeRequest
            {
                Id = id,
            };
            var result = await mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for get Employee by id
        /// </summary>
        /// <param name="id">ID of Employee</param>
        /// <returns>Action result with Employee as data</returns>
        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailV1(int id)
        {
            var query = new GetDetailEmployeeRequest()
            {
                Id = id,
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for get all Employees
        /// </summary>
        /// <returns>Action result with list of Employees as data</returns>
        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetAllV1([FromQuery] int? companyId,
                                                [FromQuery] int? degreeId,
                                                [FromQuery] int? traMajId,
                                                [FromQuery] int? bankId,
                                                [FromQuery] int? nationId,
                                                [FromQuery] int? religionId,
                                                [FromQuery] int? maritalId,
                                                [FromQuery] int? empRoleId,
                                                [FromQuery] string? countryId,
                                                [FromQuery] int? empPlaceOfResidenceWardId,
                                                [FromQuery] int? empPlaceOfBirth,
                                                [FromQuery] int? isActived,
                                                [FromQuery] string? empName,
                                                [FromQuery] string? empCode,
                                                [FromQuery] bool? isDescending,
                                                [FromQuery] int pageNumber = 0,
                                                [FromQuery] int pageSize = 10,
                                                [FromQuery] int? skip = null,
                                                [FromQuery] int? take = null)
        {
            var request = new GetAllEmployeeRequest
            {
                CompanyId = companyId,
                DegreeId = degreeId,
                TraMajId = traMajId,
                BankId = bankId,
                NationId = nationId,
                ReligionId = religionId,
                MaritalId = maritalId,
                EmpRoleId = empRoleId,
                CountryId = countryId,
                EmpPlaceOfResidenceWardId = empPlaceOfResidenceWardId,
                EmpPlaceOfBirth = empPlaceOfBirth,
                IsActived = isActived,
                EmpCode = empCode,
                EmpName = empName,
                IsDescending = isDescending,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Take = take,
                Skip = skip
            };
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for Employee login
        /// </summary>
        /// <returns>Action result with list of Employees as data</returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> EmployeeLoginV1(EmployeeLoginRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(
                new AuthenticateResponse
                {
                    Id = result.Data.Id,
                    FullName = result.Data.FirstName + " " + result.Data.LastName,
                    Token = jwtUtils.GenerateJwtToken(new UsersDTOs() { id = result.Data.Id, type = UserLoginType.EMPLOYEE.ToString() })
                }
            );
        }
    }
}
