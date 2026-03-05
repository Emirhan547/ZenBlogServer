using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class RemoveCommentCommandHandler (IRepository<Comment> _repository,IUnitOfWork _unitOfWork): IRequestHandler<RemoveCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
           var comments=await _repository.GetByIdAsync(request.Id);
            if(comments == null)
            {
                return BaseResult<object>.NotFound("Comment Not Found");
            }
            _repository.Delete(comments);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Comment Remove SuccessFully");
        }
    }
}
