 using System;
using JwtApp.Core.Application.Features.CQRS.Commands;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
	{
		public CreateProductCommandHandler(IRepository<Product> repository)
		{
            _repository = repository;
		}

        private readonly IRepository<Product> _repository;

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Product {
            CategoryId = request.CategoryId,
            Name = request.Name,
            Price = request.Price,
            Stock=request.Stock,
            });
            return Unit.Value;
        }
    }
}

