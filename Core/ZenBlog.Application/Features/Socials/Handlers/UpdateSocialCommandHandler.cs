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
    public class UpdateSocialCommandHandler(IRepository<Social> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            var socials = await _repository.GetByIdAsync(request.Id);
            if (socials == null)
            {
                return BaseResult<object>.Fail("Social Not Found");
            }
            var mappedSocials=_mapper.Map<Social>(request);
            _repository.Update(mappedSocials);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Socials updated successfully");
        }
    }
}
