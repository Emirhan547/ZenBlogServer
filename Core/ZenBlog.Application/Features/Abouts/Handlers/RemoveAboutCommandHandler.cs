using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Abouts.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Abouts.Handlers
{
    public class RemoveAboutCommandHandler(IRepository<About> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
           var abouts=await _repository.GetByIdAsync(request.Id);
            if (abouts == null) 
            {
                return BaseResult<object>.NotFound("About Not Found");
            }
            _repository.Delete(abouts);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Fail("About has been deleted successfully");
        }
    }
}
