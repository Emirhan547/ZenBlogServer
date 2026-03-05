using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class UpdateBlogCommandHandler (IRepository<Blog>  _repository,IMapper _mapper,IUnitOfWork _unitOfWork): IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
           var blogs= _mapper.Map<Blog>(request);
            _repository.Update(blogs);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Blog has been updated successfully"); 
        }
    }
}
