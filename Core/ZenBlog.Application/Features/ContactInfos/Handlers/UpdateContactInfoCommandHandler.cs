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
    public class UpdateContactInfoCommandHandler(IRepository<ContactInfo> _repository,IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<UpdateContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo =await _repository.GetByIdAsync(request.Id);
            if (contactInfo is null)
            {
                return BaseResult<object>.Fail("Contact info not found");
            }
            var mappedContactInfo = _mapper.Map(request, contactInfo);
            _repository.Update(mappedContactInfo);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Contact info updated successfully");
        }
    }
}
