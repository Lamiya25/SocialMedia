using FluentValidation;
using SocialMedia.Application.Consts;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage(Messages.EmptyNameMessage).MaximumLength(25)
                                    .WithMessage(Messages.MaximumNameSymbolMessage);

            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage(Messages.EmptyNameMessage).MaximumLength(35)
                                    .WithMessage(Messages.MaximumLastNameSymbolMessage);

            RuleFor(x => x.Email).EmailAddress().WithMessage(Messages.InvalidEmailMessage).NotNull()
                                    .WithMessage(Messages.EmptyEmailMessage);

            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage(Messages.EmptyNameMessage).MaximumLength(16)
                                    .WithMessage(Messages.MaximumUsernameSymbolMessage);
        }
    }
}