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
    public class CreateAboutCommandHandler(IRepository<About> _repository,IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<CreateAboutCommand,BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var aboutsMapped=_mapper.Map<About>(request);
            await _repository.CreateAsync(aboutsMapped);
           var UOW= await _unitOfWork.SaveChangesAsync();
            var reAboutsMapped=_mapper.Map<CreateAboutCommand>(UOW);
            return BaseResult<object>.Success(reAboutsMapped);
            
        }
    }
}
