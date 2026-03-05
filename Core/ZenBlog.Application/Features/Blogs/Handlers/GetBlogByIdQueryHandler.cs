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
    public class GetBlogByIdQueryHandler(IRepository<Blog> _repository, IMapper _mapper) : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if(blog == null)
            {
                return BaseResult<GetBlogByIdQueryResult>.NotFound("Blog Not Found");
            }
            var mappedBlog=_mapper.Map<GetBlogByIdQueryResult>(blog);
            return BaseResult<GetBlogByIdQueryResult>.Success(mappedBlog);  
        }
    }
}
    