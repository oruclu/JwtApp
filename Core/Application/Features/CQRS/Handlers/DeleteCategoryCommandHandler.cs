using System;
using JwtApp.Core.Application.Features.CQRS.Commands;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
	{
		public DeleteCategoryCommandHandler(IRepository<Category> repository)
		{
            _repository = repository;
		}

        private readonly IRepository<Category> _repository;

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await _repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}

