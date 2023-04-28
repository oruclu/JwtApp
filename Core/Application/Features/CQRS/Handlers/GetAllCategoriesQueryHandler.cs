using System;
using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Queries;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers
{
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<CategoriesListDto>>
	{
		public GetAllCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
		}

        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public async Task<List<CategoriesListDto>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data =await _repository.GetAllAsync();
            return _mapper.Map<List<CategoriesListDto>>(data);
        }
    }
}

