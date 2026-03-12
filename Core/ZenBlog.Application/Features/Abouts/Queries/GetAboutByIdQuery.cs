using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Abouts.Result;

namespace ZenBlog.Application.Features.Abouts.Queries;

    public record GetAboutByIdQuery(Guid Id):IRequest<BaseResult<GetAboutByIdQueryResult>>;
