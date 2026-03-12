using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Abouts.Commands
{
    public record CreateAboutCommand:IRequest<BaseResult<object>>
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
    }
}
