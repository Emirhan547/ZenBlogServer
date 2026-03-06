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
    public class GetMessagesQueryHandler (IRepository<Message> _repository,IMapper _mapper): IRequestHandler<GetMessagesQuery, BaseResult<List<GetMessagesQueryResult>>>
    {
        public async Task<BaseResult<List<GetMessagesQueryResult>>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
           var message=await _repository.GetAllAsync();
            var mapped=_mapper.Map<List<GetMessagesQueryResult>>(message);
            return BaseResult<List<GetMessagesQueryResult>>.Success(mapped);
        }
    }
}
