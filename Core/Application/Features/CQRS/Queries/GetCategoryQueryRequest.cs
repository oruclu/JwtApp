using System;
using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Queries
{
	public class GetCategoryQueryRequest : IRequest<CategoriesListDto?>
	{
		public GetCategoryQueryRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}

