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
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Content).MaximumLength(2500).WithMessage(Messages.MaximumSymbolMessage);

        }
    }
}