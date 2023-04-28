using System;
using System.Data;
using JwtApp.Core.Application.Features.CQRS.Commands;
using JwtApp.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    [Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		public CategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		private readonly IMediator _mediator;

		[HttpGet]
		public async Task<IActionResult> List()
		{
			var result = await _mediator.Send(new GetAllCategoryQueryRequest());
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			var result = await _mediator.Send(new GetCategoryQueryRequest(id));
			return result == null ? NotFound() : Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
		{
			await _mediator.Send(request);
			return Created("", request);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
		{
			await _mediator.Send(request);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _mediator.Send(new DeleteCategoryCommandRequest(id));
			return Ok();
		}

	}
}

