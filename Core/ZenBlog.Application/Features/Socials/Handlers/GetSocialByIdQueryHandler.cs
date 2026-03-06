using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class GetSocialByIdQueryHandler(IRepository<Social> _repository,IMapper _mapper) : IRequestHandler<GetSocialByIdQuery, BaseResult<GetSocialByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialByIdQueryResult>> Handle(GetSocialByIdQuery request, CancellationToken cancellationToken)
        {
            var socials=await _repository.GetByIdAsync(request.Id);
            if(socials == null)
            {
                return BaseResult<GetSocialByIdQueryResult>.Fail("Social Not Found");
            }
            var mappedSocials = _mapper.Map<GetSocialByIdQueryResult>(socials);
            return BaseResult<GetSocialByIdQueryResult>.Success(mappedSocials);
        }
    }
}
