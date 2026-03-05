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
    public class GetCommentByIdQueryHandler (IRepository<Comment> _repository,IMapper _mapper): IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comments=await _repository.GetByIdAsync(request.Id);
            if(comments == null)
            {
                return BaseResult<GetCommentByIdQueryResult>.NotFound("Comment Not Found");
            }
            var mappedComment=_mapper.Map<GetCommentByIdQueryResult>(comments);
            return BaseResult<GetCommentByIdQueryResult>.Success(mappedComment);
        }
    }
}
