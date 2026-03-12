using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Abouts.Queries;
using ZenBlog.Application.Features.Abouts.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Abouts.Handlers
{
    public class GetAboutsQueryHandler(IRepository<About> _repository,IMapper _mapper) : IRequestHandler<GetAboutsQuery, BaseResult<List<GetAboutsQueryResult>>>
    {
        public async Task<BaseResult<List<GetAboutsQueryResult>>> Handle(GetAboutsQuery request, CancellationToken cancellationToken)
        {
            var abouts = await _repository.GetAllAsync();
            var mappedAbouts=_mapper.Map<List<GetAboutsQueryResult>>(abouts);
            return BaseResult<List<GetAboutsQueryResult>>.Success(mappedAbouts);
        }
    }
}
