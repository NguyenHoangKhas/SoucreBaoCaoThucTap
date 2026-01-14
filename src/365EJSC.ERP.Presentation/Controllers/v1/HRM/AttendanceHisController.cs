using _365EJSC.ERP.Application.Requests.HRM.AttendanceHis;
using _365EJSC.ERP.Presentation.Abstractions;
using _365EJSC.ERP.Presentation.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365EJSC.ERP.Presentation.Controllers.v1.HRM
{
    [ApiVersion(1)]
    [Route(RouteConstant.API_PREFIX + RouteConstant.ATTENDANCE_HIS_ROUTE)]
    public class AttendanceHisController : ApiController
    {
        private readonly IMediator mediator;

        public AttendanceHisController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Create Attendance History
        /// </summary>
        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> CreateV1(CreateHrmAttendanceHisRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Update Attendance History
        /// </summary>
        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateV1(int id, [FromBody] UpdateHrmAttendanceHisRequest request)
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Delete Attendance History
        /// </summary>
        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteV1(int id)
        {
            var command = new DeleteHrmAttendanceHisRequest { Id = id };
            var result = await mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Attendance History list with optional filters and pagination
        /// </summary>
        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetAllV1([FromQuery] GetAllAttendanceHisRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }



    }

}
