using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class GetSubCommentsQueryHandler(IRepository<SubComment> _repository,IMapper _mapper) : IRequestHandler<GetSubCommentsQuery, BaseResult<List<GetSubCommentQueryResult>>>
    {
        public async Task<BaseResult<List<GetSubCommentQueryResult>>> Handle(GetSubCommentsQuery request, CancellationToken cancellationToken)
        {
            var subComments = await _repository.GetAllAsync();
            var mappedSubComments=_mapper.Map<List<GetSubCommentQueryResult>>(subComments);
            return BaseResult<List<GetSubCommentQueryResult>>.Success(mappedSubComments);
        }
    }
}
