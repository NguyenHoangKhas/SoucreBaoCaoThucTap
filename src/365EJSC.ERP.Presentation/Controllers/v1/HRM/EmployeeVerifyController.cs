using _365EJSC.ERP.Application.Requests.HRM.EmployeeVerify;
using _365EJSC.ERP.Presentation.Abstractions;
using _365EJSC.ERP.Presentation.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365EJSC.ERP.Presentation.Controllers.v1.HRM
{
    /// <summary>
    /// Controller version 1 for EmployeeVerify apis
    /// </summary>
    [ApiVersion(1)]
    [Route(RouteConstant.API_PREFIX + RouteConstant.EMPLOYEE_VERIFY_ROUTE)]
    public class EmployeeVerifyController : ApiController
    {
        private readonly IMediator mediator;

        public EmployeeVerifyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Api version 1 for create EmployeeVerify
        /// </summary>
        /// <param name="request">Request to create EmployeeVerify</param>
        /// <returns>Action result</returns>
        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> CreateV1(CreateEmployeeVerifyRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for update EmployeeVerify
        /// </summary>
        /// <param name="id">Id of EmployeeVerify need to be updated</param>
        /// <param name="request">Request body contains content to update</param>
        /// <returns></returns>
        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateV1(int id, [FromBody] UpdateEmployeeVerifyRequest request)
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for delete EmployeeVerify
        /// </summary>
        /// <param name="id">id of EmployeeVerify</param>
        /// <returns>Action result</returns>
        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteV1(int id)
        {
            var command = new DeleteEmployeeVerifyRequest()
            {
                Id = id,
            };
            var result = await mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for get EmployeeVerify by id
        /// </summary>
        /// <param name="id">ID of EmployeeVerify</param>
        /// <returns>Action result with EmployeeVerify as data</returns>
        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailV1(int id)
        {
            var query = new GetDetailEmployeeVerifyRequest()
            {
                Id = id,
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for get all EmployeeVerifys
        /// </summary>
        /// <returns>Action result with list of EmployeeVerifys as data</returns>
        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetAllV1([FromQuery] int? employeeId, int? IsActived)
        {
            var request = new GetAllEmployeeVerifyRequest() { EmployeeId = employeeId, IsActived = IsActived };
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
