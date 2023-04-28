using System;
using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Domain;

namespace JwtApp.Core.Application.Mappings
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			this.CreateMap<Product, ProductListDto>().ReverseMap();
		}
	}
}

