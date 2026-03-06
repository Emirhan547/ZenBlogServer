using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands
{
    public record CreateSocialCommand:IRequest<BaseResult<object>>
    {
        public string Title { get; init; }
        public string Url { get; init; }
        public string Icon { get; init; }
    }
}
