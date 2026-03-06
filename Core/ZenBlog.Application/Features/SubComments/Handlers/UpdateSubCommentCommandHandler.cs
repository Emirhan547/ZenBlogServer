using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class UpdateSubCommentCommandHandler(IRepository<SubComment> _repository,IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<UpdateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment=await _repository.GetByIdAsync(request.Id);
            if (subComment == null)
            {
                return BaseResult<object>.Fail("SubComment not found");
            }

            _mapper.Map(request,subComment);
            _repository.Update(subComment);
            await _unitOfWork.SaveChangesAsync();

            return BaseResult<object>.Success("SubComment Updated");
        }
    }
}
  