using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Abouts.Commands;

namespace ZenBlog.Application.Features.Abouts.Validators
{
    public class CreateAboutValidator:AbstractValidator<CreateAboutCommand>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl is required");
        }
    }
}
