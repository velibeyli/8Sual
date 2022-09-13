using _8Sual.DTO;
using FluentValidation;

namespace _8Sual.Validation
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username can not be empty")
                .NotNull().WithMessage("Username can not be null")
                .MinimumLength(6).WithMessage("Username lenght must be at least 6 character");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password can not be empty")
                .NotNull().WithMessage("Password can not be null")
                .MinimumLength(8).WithMessage("Password lenght must be at least 6 character");
        }
    }
}
