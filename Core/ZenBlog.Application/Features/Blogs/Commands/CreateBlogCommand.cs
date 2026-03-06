using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Commands
{
    public record CreateBlogCommand(string Title, string CoverImage, string BlogImage, string Description, Guid CategoryId, string UserId) : IRequest<BaseResult<object>>;

    }

