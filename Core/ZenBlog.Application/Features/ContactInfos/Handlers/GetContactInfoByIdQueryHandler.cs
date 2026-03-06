using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.ContactInfos.Queries;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class GetContactInfoByIdQueryHandler (IRepository<ContactInfo> _repository,IMapper _mapper): IRequestHandler<GetContactInfoByIdQuery, BaseResult<GetContactInfoByIdQueryResult>>
    {
        public async Task<BaseResult<GetContactInfoByIdQueryResult>> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            if (values is null)
            {
                return BaseResult<GetContactInfoByIdQueryResult>.Fail("Contact info not found.");
            }
            var mapped=_mapper.Map<GetContactInfoByIdQueryResult>(values);
            return BaseResult<GetContactInfoByIdQueryResult>.Success(mapped);
        }
    }
}
 