using _365EJSC.ERP.Application.Requests.Define.WebLocalWardsV2;
using _365EJSC.ERP.Presentation.Abstractions;
using _365EJSC.ERP.Presentation.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365EJSC.ERP.Presentation.Controllers.v1.Define
{
	/// <summary>
    /// Controller version 1 for WebLocalWardsV2 apis
    /// </summary>
    [ApiVersion(1)]
    [Route(RouteConstant.API_PREFIX + RouteConstant.WEB_LOCAL_WARDS_V2_ROUTE)]
    public class WebLocalWardsV2Controller : ApiController
    {
		private readonly IMediator mediator;

		public WebLocalWardsV2Controller(IMediator mediator)
		{
			this.mediator = mediator;
		}

		/// <summary>
		/// Api version 1 for create WebLocalWardsV2
		/// </summary>
		/// <param name="request">Request to create WebLocalWardsV2</param>
		/// <returns>Action result</returns>
		[MapToApiVersion(1)]
		[HttpPost]
		public async Task<IActionResult> CreateV1(CreateWebLocalWardsV2Request request)
		{
			var result = await mediator.Send(request);
			return Ok(result);
		}

		/// <summary>
		/// Api version 1 for update WebLocalWardsV2c
		/// </summary>
		/// <param name="id">Id of WebLocalWardsV2 need to be updated</param>
		/// <param name="request">Request body contains content to update</param>
		/// <returns></returns>
		[MapToApiVersion(1)]
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateV1(int id, [FromBody] UpdateWebLocalWardsV2Request request)
		{
			request.Id = id;
			var result = await mediator.Send(request);
			return Ok(result);
		}

		/// <summary>
		/// Api version 1 for delete WebLocalWardsV2
		/// </summary>
		/// <param name="id">id of WebLocalWardsV2</param>
		/// <returns>Action result</returns>
		[MapToApiVersion(1)]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteV1(int id)
		{
			var command = new DeleteWebLocalWardsV2Request()
			{
				Id = id
			};
			var result = await mediator.Send(command);
			return Ok(result);
		}

		/// <summary>
		/// Api version 1 for get WebLocalWardsV2 by id
		/// </summary>
		/// <param name="id">ID of WebLocalWardsV2</param>
		/// <returns>Action result with WebLocalWardsV2 as data</returns>
		[MapToApiVersion(1)]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetDetailV1(int id)
		{
			var query = new GetDetailWebLocalWardsV2Request()
			{
				Id = id,
			};
			var result = await mediator.Send(query);
			return Ok(result);
		}

		/// <summary>
		/// Api version 1 for get all WebLocalWardsV2
		/// </summary>
		/// <returns>Action result with list of WebLocalWardsV2 as data</returns>
		[MapToApiVersion(1)]
		[HttpGet]
		public async Task<IActionResult> GetAllV1()
		{
			var query = new GetAllWebLocalWardsV2Request();
			var result = await mediator.Send(query);
			return Ok(result);
		}
        [MapToApiVersion(1)]
        [HttpGet("parent/{wardPid}")]
        public async Task<IActionResult> GetAllByParentIdV1(int wardPid)
        {
            var query = new GetAllByParentIdWebLocalWardsV2Request
            {
                WardPid = wardPid
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }


    }
}
