using _365EJSC.ERP.Application.Requests.HRM.EmployeeCompany;
using _365EJSC.ERP.Presentation.Abstractions;
using _365EJSC.ERP.Presentation.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365EJSC.ERP.Presentation.Controllers.v1.HRM
{
    /// <summary>
    /// Controller version 1 for EmployeeCompany APIs
    /// </summary>
    [ApiVersion(1)]
    [Route(RouteConstant.API_PREFIX + RouteConstant.EMPLOYEE_COMPANY_ROUTE)]
    public class EmployeeCompanyController : ApiController
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor for <see cref="EmployeeCompanyController"/>, inject needed dependency
        /// </summary>
        public EmployeeCompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// API version 1 for creating an EmployeeCompany
        /// </summary>
        /// <param name="request">Request to create EmployeeCompany</param>
        /// <returns>Action result</returns>
        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> CreateV1(CreateEmployeeCompanyRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// API version 1 for updating an EmployeeCompany
        /// </summary>
        /// <param name="id">ID of EmployeeCompany to be updated</param>
        /// <param name="request">Request body containing content to update</param>
        /// <returns>Action result</returns>
        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateV1(int id, [FromBody] UpdateEmployeeCompanyRequest request)
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// API version 1 for deleting an EmployeeCompany
        /// </summary>
        /// <param name="id">ID of EmployeeCompany</param>
        /// <returns>Action result</returns>
        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteV1(int id)
        {
            var command = new DeleteEmployeeCompanyRequest
            {
                Id = id
            };
            var result = await mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// API version 1 for getting an EmployeeCompany by ID
        /// </summary>
        /// <param name="id">ID of EmployeeCompany</param>
        /// <returns>Action result with EmployeeCompany as data</returns>
        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailV1(int id)
        {
            var query = new GetDetailEmployeeCompanyRequest
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// API version 1 for getting all EmployeeCompanies
        /// </summary>
        /// <returns>Action result with list of EmployeeCompanies as data</returns>
        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetAllV1()
        {
            var request = new GetAllEmployeeCompanyRequest();
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
