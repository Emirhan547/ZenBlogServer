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
    public class GetReadMessagesQueryHandler (IRepository<Message> _repository,IMapper _mapper): IRequestHandler<GetReadMessagesQuery, BaseResult<List<GetReadMessagesQueryResult>>>
    {
        public async Task<BaseResult<List<GetReadMessagesQueryResult>>> Handle(GetReadMessagesQuery request, CancellationToken cancellationToken)
        {
           var messages=await _repository.GetAllAsync(x=>x.IsRead ==true);
            var mappedMessages=_mapper.Map<List<GetReadMessagesQueryResult>>(messages);
            return BaseResult<List<GetReadMessagesQueryResult>>.Success(mappedMessages);
        }
    }
}
