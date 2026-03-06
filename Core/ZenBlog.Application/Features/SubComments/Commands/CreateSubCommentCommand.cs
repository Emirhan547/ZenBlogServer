using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public record CreateSubCommentCommand:IRequest<BaseResult<object>>
    {
        public string UserId { get; init; }
        public string Body { get; init; }
        [JsonIgnore]
        public DateTime CommentDate { get; init; }= DateTime.Now;
        public Guid CommentId { get; init; }
    }
}
