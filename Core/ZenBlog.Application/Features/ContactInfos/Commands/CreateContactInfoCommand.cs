using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands
{
    public record CreateContactInfoCommand(string Address, string Email, string Phone, string MapUrl) : IRequest<BaseResult<object>>;
    }

