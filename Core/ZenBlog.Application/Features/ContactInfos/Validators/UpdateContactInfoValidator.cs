using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.ContactInfos.Commands;

namespace ZenBlog.Application.Features.ContactInfos.Validators
{
    public class UpdateContactInfoValidator:AbstractValidator<UpdateContactInfoCommand>
    {
        public UpdateContactInfoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Map URL is required.");

        }
    }
}
