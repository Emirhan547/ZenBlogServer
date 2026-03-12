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
    public class GetAboutByIdQueryHandler(IRepository<About> _repository,IMapper _mapper) : IRequestHandler<GetAboutByIdQuery, BaseResult<GetAboutByIdQueryResult>>
    {
        public async Task<BaseResult<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var abouts=await  _repository.GetByIdAsync(request.Id);
            if(abouts is  null)
            {
                return BaseResult<GetAboutByIdQueryResult>.Fail("Abouts Not Found");
            }
            var aboutsMapped=_mapper.Map<GetAboutByIdQueryResult>(abouts);
            return BaseResult<GetAboutByIdQueryResult>.Success(aboutsMapped);
        }
    }
}
