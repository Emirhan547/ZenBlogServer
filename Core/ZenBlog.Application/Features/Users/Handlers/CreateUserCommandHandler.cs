using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler(UserManager<AppUser> _userManager,IMapper _mapper) : IRequestHandler<CreateUserCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           var user=_mapper.Map<AppUser>(request);
            var results = await _userManager.CreateAsync(user, request.Password);
            if (!results.Succeeded)
            {
                return BaseResult<object>.Fail(results.Errors);
            }
            return BaseResult<object>.Success(results);
        }
    }
}
