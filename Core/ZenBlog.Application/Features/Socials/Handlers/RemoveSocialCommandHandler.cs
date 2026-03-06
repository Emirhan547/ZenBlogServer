using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class RemoveSocialCommandHandler(IRepository<Social> _repository ,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSocialCommand request, CancellationToken cancellationToken)
        {
            var socials=await _repository.GetByIdAsync(request.Id);
            if (socials == null)
            {
                return BaseResult<object>.Fail("Social Not Found");
            }
            _repository.Delete(socials);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Socials Deleted successfully");
        }
    }
}
