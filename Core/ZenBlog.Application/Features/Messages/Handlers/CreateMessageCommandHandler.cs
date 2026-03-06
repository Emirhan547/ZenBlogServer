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
    public class CreateMessageCommandHandler (IRepository<Message> _repository,IMapper _mapper,IUnitOfWork _unitOfWork): IRequestHandler<CreateMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var mapped=_mapper.Map<Message>(request);
            await _repository.CreateAsync(mapped);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Message created successfully.");
        }
    }
}
