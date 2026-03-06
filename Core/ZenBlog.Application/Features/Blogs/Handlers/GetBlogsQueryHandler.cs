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
    public class GetBlogsQueryHandler(IRepository<Blog>_repository,IMapper _mapper) : IRequestHandler<GetBlogsQuery, BaseResult<List<GetBlogsQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogsQueryResult>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetAllAsync();
            var mappedBlogs=_mapper.Map<List<GetBlogsQueryResult>>(blogs);
            return BaseResult<List<GetBlogsQueryResult>>.Success(mappedBlogs);
        }
    }
}
  