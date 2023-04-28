using System;
using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Domain;

namespace JwtApp.Core.Application.Mappings
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			this.CreateMap<Category, CategoriesListDto>().ReverseMap();
		}
	}
}

