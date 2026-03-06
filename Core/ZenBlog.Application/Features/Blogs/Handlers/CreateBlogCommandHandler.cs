using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class CreateBlogCommandHandler (IRepository<Blog> _repository,IUnitOfWork _unitOfWork,IMapper _mapper): IRequestHandler<CreateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
           var blogs=_mapper.Map<Blog>(request);
            await _repository.CreateAsync(blogs);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(blogs);
        }
    }
}
