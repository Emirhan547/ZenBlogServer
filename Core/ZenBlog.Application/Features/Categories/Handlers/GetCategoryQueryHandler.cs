using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class GetCategoryQueryHandler(IRepository<Category> _repository, IMapper _mapper) : IRequestHandler<GetCategoryQuery, BaseResult<List<GetCategoryQueryResult>>>
    {
        public async Task<BaseResult<List<GetCategoryQueryResult>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            var result = _mapper.Map<List<GetCategoryQueryResult>>(categories);
            return BaseResult<List<GetCategoryQueryResult>>.Success(result);
        }
    }
}
