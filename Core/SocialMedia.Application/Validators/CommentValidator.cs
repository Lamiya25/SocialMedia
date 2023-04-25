using FluentValidation;
using SocialMedia.Application.Consts;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Content).NotNull().WithMessage(Messages.EmptyCommentMessage);
            RuleFor(x => x.Content).MaximumLength(255).WithMessage(Messages.MaximumSymbolMessage);
        }
    }
}