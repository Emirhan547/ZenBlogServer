using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    internal class GetLatest5BlogsQueryHandler(IRepository<Blog> _repository,IMapper _mapper) : IRequestHandler<GetLatest5BlogsQuery, BaseResult<List<GetLatest5BlogsQueryResult>>>
    {
        public async Task<BaseResult<List<GetLatest5BlogsQueryResult>>> Handle(GetLatest5BlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs= _repository.GetQuery().OrderByDescending(x=> x.Id).Take(5).ToList();
            var mappedBlogs=_mapper.Map<List<GetLatest5BlogsQueryResult>>(blogs);
            return BaseResult<List<GetLatest5BlogsQueryResult>>.Success(mappedBlogs);
        }
    }
}
