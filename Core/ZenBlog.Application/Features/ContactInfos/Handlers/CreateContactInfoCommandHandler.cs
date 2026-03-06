using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class CreateContactInfoCommandHandler (IRepository<ContactInfo> _repository,IMapper _mapper,IUnitOfWork _unitOfWork): IRequestHandler<CreateContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
           var mappedContactInfo = _mapper.Map<ContactInfo>(request);
            await _repository.CreateAsync(mappedContactInfo);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(mappedContactInfo);
        }
    }
}
