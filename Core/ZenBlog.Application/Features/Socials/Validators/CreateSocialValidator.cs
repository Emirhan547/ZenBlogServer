using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Socials.Commands;

namespace ZenBlog.Application.Features.Socials.Validators
{
    public class CreateSocialValidator:AbstractValidator<CreateSocialCommand>
    {
        public CreateSocialValidator()
        { 
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url is required");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon is required");
        }
    }
}
