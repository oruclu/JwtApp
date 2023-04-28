using System;
using JwtApp.Core.Application.Features.CQRS.Commands;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
	{
		public DeleteProductCommandHandler(IRepository<Product> repository)
		{
            _repository = repository;
		}

        private readonly IRepository<Product> _repository;

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = await _repository.GetByIdAsync(request.Id);
            if (deleteProduct != null)
            { 
            await _repository.RemoveAsync(deleteProduct);
            }
            return Unit.Value;
        }
    }
}

