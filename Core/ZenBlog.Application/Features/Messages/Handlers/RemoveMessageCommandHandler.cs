using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class RemoveMessageCommandHandler (IRepository<Message> _repository,IUnitOfWork _unitOfWork): IRequestHandler<RemoveMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
        {
           var message=await _repository.GetByIdAsync(request.Id);
            if(message == null)
            {
                return BaseResult<object>.Fail("Message Not Found");
            }
            _repository.Delete(message);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(message);
        }
    }
}
