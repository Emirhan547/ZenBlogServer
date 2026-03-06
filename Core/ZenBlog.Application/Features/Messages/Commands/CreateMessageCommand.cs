using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public record CreateMessageCommand:IRequest<BaseResult<object>>
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Subject { get; init; }
        public string MessageBody { get; init; }
        public bool IsRead { get; init; }
    }
}
