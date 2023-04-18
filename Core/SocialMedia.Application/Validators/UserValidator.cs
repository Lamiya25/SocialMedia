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
            RuleFor(x=>x.FirstName).NotNull().NotEmpty().WithMessage(Messages.EmptyNameMessage).MaximumLength(25)
                                    .WithMessage("Name must be less than 25 characters");

            RuleFor(x=>x.LastName).NotNull().NotEmpty().WithMessage(Messages.EmptyNameMessage).MaximumLength(35)
                                    .WithMessage("Name must be less than 35 characters");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is invalid").NotNull().WithMessage("Email cannot be empty");

            RuleFor(x=>x.UserName).NotNull().NotEmpty().WithMessage(Messages.EmptyNameMessage).MaximumLength(16)
                                    .WithMessage("Name must be less than 16 characters");
        }
    }
}
