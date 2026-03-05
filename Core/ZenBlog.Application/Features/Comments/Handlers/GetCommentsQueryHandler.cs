using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class GetCommentsQueryHandler (IRepository<Comment> _repository,IMapper _mapper): IRequestHandler<GetCommentsQuery, BaseResult<List<GetCommentsQueryResult>>>
    {
        public async Task<BaseResult<List<GetCommentsQueryResult>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetAllAsync();
            var mappedComment=_mapper.Map<List<GetCommentsQueryResult>>(comments);
            return BaseResult<List<GetCommentsQueryResult>>.Success(mappedComment);
        }
    }
}
