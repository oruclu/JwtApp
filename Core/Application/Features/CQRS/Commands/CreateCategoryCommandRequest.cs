using System;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Commands
{
	public class CreateCategoryCommandRequest : IRequest
	{
		public string? Definition { get; set; }	
	}
}

