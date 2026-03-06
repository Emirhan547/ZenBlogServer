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
    public class GetSubCommentByIdQueryHandler (IRepository<SubComment> _repository,IMapper _mapper): IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetSubCommentByIdQueryResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
        {
           var subComments=await _repository.GetByIdAsync(request.Id);
            if(subComments == null)
            {
                return BaseResult<GetSubCommentByIdQueryResult>.NotFound("SubComment Not Found");

            }
            var mappedSubComment= _mapper.Map<GetSubCommentByIdQueryResult>(subComments);
            return BaseResult<GetSubCommentByIdQueryResult>.Success(mappedSubComment);
        }
    }
}
