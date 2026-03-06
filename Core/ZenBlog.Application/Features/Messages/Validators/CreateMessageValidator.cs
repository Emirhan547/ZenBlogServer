using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Messages.Commands;

namespace ZenBlog.Application.Features.Messages.Validators
{
    public class CreateMessageValidator:AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                                  .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Message body is required.");

        }
    }
}
