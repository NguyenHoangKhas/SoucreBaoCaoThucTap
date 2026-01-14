using _365EJSC.ERP.Application.Requests.HRM.Attendance;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Presentation.Abstractions;
using _365EJSC.ERP.Presentation.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365EJSC.ERP.Presentation.Controllers.v1.HRM
{
    /// <summary>
    /// Controller version 1 for Attendance APIs
    /// </summary>
    [ApiVersion(1)]
    [Route(RouteConstant.API_PREFIX + RouteConstant.ATTENDANCE_ROUTE)]
    public class AttendanceController : ApiController
    {
        private readonly IMediator mediator;

        public AttendanceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Api version 1 for create Attendance
        /// </summary>
        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> CreateV1(CreateHrmAttendanceRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for update Attendance
        /// </summary>
        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateV1(int id, [FromBody] UpdateHrmAttendanceRequest request)
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for delete Attendance
        /// </summary>
        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteV1(int id)
        {
            var command = new DeleteHrmAttendanceRequest { Id = id };
            var result = await mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1: Lấy danh sách Attendance
        /// </summary>
        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetAllV1([FromQuery] GetAllAttendanceRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }


    }
}
