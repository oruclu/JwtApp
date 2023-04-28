using System;
using JwtApp.Core.Application.Features.CQRS.Commands;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
	{
		public UpdateProductCommandHandler(IRepository<Product> repository)
		{
            _repository = repository;
		}

        private readonly IRepository<Product> _repository;

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _repository.GetByIdAsync(request.Id);
            if (updatedProduct != null)
            {
                updatedProduct.CategoryId = request.CategoryId;
                updatedProduct.Stock = request.Stock;
                updatedProduct.Price = request.Price;
                updatedProduct.Name = request.Name;

                await _repository.UpdateAsync(updatedProduct);
            }
            return Unit.Value;
        }
    }
}

