using System;
using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Queries
{
	public class GetAllCategoryQueryRequest : IRequest<List<CategoriesListDto>>
	{
		public GetAllCategoryQueryRequest()
		{
		}
	}
}

