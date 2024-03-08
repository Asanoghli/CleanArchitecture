using CleanArchitecture.Application.Resources;
using CleanArchitecture.Common.Constants;
using FluentValidation;

namespace CleanArchitecture.Application.Contracts.Admin.Users.Requests;
public class AdminCreateUserRequest
{
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public DateOnly? birthDate { get; set; }
    public string? email { get; set; }
    public string? userName { get; set; }
    public string? password { get; set; }
}
public class AdminCreateUserRequestValidation : AbstractValidator<AdminCreateUserRequest>
{
    public AdminCreateUserRequestValidation()
    {
        RuleFor(user => user.userName)
            .NotEmpty()
            .WithMessage(ResourceLocalizer.UserUsernameIsEmpty)
            .MinimumLength(RequestConstants.MINIMUM_USERNAME_LENGTH)
            .WithMessage(string.Format(ResourceLocalizer.UserUsernameIsTooShort, RequestConstants.MINIMUM_USERNAME_LENGTH));

        RuleFor(user => user.firstName)
            .NotEmpty()
            .WithMessage(ResourceLocalizer.UserFirstNameIsRequired)
            .MinimumLength(RequestConstants.MINIMUM_FIRSTNAME_LENGTH)
            .WithMessage(string.Format(ResourceLocalizer.UserFirstNameIsTooShort, RequestConstants.MINIMUM_FIRSTNAME_LENGTH));

        RuleFor(user => user.lastName)
            .NotEmpty()
            .WithMessage(ResourceLocalizer.UserLastNameIsRequired)
            .MinimumLength(RequestConstants.MINIMUM_LASTNAME_LENGTH)
            .WithMessage(string.Format(ResourceLocalizer.UserLastNameIsTooShort, RequestConstants.MINIMUM_LASTNAME_LENGTH));

        RuleFor(user => user.email)
            .NotEmpty()
            .WithMessage(ResourceLocalizer.UserEmailIsRequired)
            .EmailAddress()
            .WithMessage(ResourceLocalizer.UserEmailIsIncorrect);

        RuleFor(user => user.password)
            .NotEmpty()
            .WithMessage(ResourceLocalizer.UserPasswordIsRequired)
            .MinimumLength(RequestConstants.MINIMUM_PASSWORD_LENGTH)
            .WithMessage(string.Format(ResourceLocalizer.UserPasswordIsTooShort, RequestConstants.MINIMUM_PASSWORD_LENGTH));

    }
}
