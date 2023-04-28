using System;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public DeleteCategoryCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

