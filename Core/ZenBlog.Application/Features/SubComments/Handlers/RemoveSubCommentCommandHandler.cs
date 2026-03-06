using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class RemoveSubCommentCommandHandler (IRepository<SubComment> _repository,IUnitOfWork _unitOfWork): IRequestHandler<RemoveSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment=await _repository.GetByIdAsync(request.Id);
            if (subComment is null)
            {
                return BaseResult<object>.Fail("SubComment not found");
            }
            _repository.Delete(subComment);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("SubComment Deleted");
        }
    }
}
