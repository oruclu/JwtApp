 using System;
using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Queries
{
	public class GetProductQueryRequest : IRequest<ProductListDto>
	{
		public GetProductQueryRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}

