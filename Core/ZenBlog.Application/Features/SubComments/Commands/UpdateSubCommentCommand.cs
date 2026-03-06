using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public class UpdateSubCommentCommand:IRequest<BaseResult<object>>
    {
        public Guid Id { get; init; }
        public string UserId { get; init; }
        public string Body { get; init; }
        public Guid CommentId { get; init; }
    }
}
