using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetMessageByIdQueryHandler(IRepository<Message>_repository, IMapper _mapper) : IRequestHandler<GetMessageByIdQuery, BaseResult<GetMessageByIdQueryResult>>
    {
        public async Task<BaseResult<GetMessageByIdQueryResult>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetByIdAsync(request.Id);
            if(message == null)
            {
                return BaseResult<GetMessageByIdQueryResult>.Fail("Message Not Found");
            }
            var mappedMessage=_mapper.Map<GetMessageByIdQueryResult>(message);
            return BaseResult<GetMessageByIdQueryResult>.Success(mappedMessage);
        }
    }
}
