using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class UpdateCommentCommandHandler (IRepository<Comment> _repository,IMapper _mapper,IUnitOfWork _unitOfWork): IRequestHandler<UpdateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
           var comments=await _repository.GetByIdAsync(request.Id);
            if(comments == null)
            {
                return BaseResult<object>.NotFound("Comment Not Found");
            }
            var mappedComment=_mapper.Map<Comment>(comments);
             _repository.Update(mappedComment);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Comment Updatede SuccessFully");

        }
    }
}
