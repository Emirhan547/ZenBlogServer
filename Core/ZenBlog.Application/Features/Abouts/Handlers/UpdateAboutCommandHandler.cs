using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Application.Features.Abouts.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Abouts.Handlers
{
    public class UpdateAboutCommandHandler (IRepository<About> _repository,IMapper _mapper,IUnitOfWork _unitOfWork): IRequestHandler<UpdateAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
           var abouts=await _repository.GetByIdAsync(request.Id);
            if(abouts == null)
            {
                return BaseResult<object>.NotFound("Abouts Not Found");
            }
           var aboutsMapped=_mapper.Map<About>(abouts);
            _repository.Update(aboutsMapped);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("About has been updated successfully");

        }
    }
}
