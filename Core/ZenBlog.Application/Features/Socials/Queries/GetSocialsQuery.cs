using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Socials.Result;

namespace ZenBlog.Application.Features.Socials.Queries
{
    public class GetSocialsQuery:IRequest<BaseResult<List<GetSocialsQueryResult>>>
    {
    }
}
