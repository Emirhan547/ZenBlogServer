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
    public class CreateSocialCommandHandler(IRepository<Social> _repository,IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<CreateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
        {
            var socials= _mapper.Map<Social>(request);
            await _repository.CreateAsync(socials);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(socials);
        }
    }
}
