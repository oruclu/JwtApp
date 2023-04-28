 using System;
using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Queries;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers
{
	public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoriesListDto?>
	{
		public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
		}
        private readonly IRepository<Category> _repository;

        private readonly IMapper _mapper;

        public async Task<CategoriesListDto?> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<CategoriesListDto>(result);
        }
    }
}

