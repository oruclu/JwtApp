using System;
using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Queries
{
	public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
	{
		public string Username { get; set; } = null!;

		public string Password { get; set; } = null!;

	}
}

