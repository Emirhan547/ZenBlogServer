using AutoMapper;
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
    public class UpdateMessageCommandHandler(IRepository<Message> _repository,IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
           var message=await _repository.GetByIdAsync(request.Id);
            if (message is null)
            {
                return BaseResult<object>.Fail("Message Not Found");
            }
            _mapper.Map(request, message);
            _repository.Update(message);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Message Updated Successfully");
        }
    }
}
