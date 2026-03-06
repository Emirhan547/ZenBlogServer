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
    public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo =await _repository.GetByIdAsync(request.Id);
            if(contactInfo==null)
            {
                return BaseResult<object>.NotFound("Contact Info Not Found");
            }
            _repository.Delete(contactInfo);
           await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Contact Info Deleted Successfully");
        }
    }
}
