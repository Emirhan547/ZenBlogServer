using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.SubComments.Commands;

namespace ZenBlog.Application.Features.SubComments.Validators
{
    public class UpdateSubCommentValidator:AbstractValidator<UpdateSubCommentCommand>
    {
        public UpdateSubCommentValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("Comment is required");
            RuleFor(x => x.Body).NotEmpty().WithMessage("Comment is required");
        }
    }
}
