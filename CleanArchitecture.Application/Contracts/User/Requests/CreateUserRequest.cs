using CleanArchitecture.Application.Resources;
using FluentValidation;
using System.Globalization;

namespace CleanArchitecture.Application.Contracts.User.Requests;
public class CreateUserRequest
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateOnly birthDate { get; set; }
    public string email { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
}
public class CreateUserRequestValidation : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidation()
    {
        var culture = CultureInfo.CurrentCulture;
        RuleFor(user=>user.userName).NotEmpty().WithMessage(ResourceLocalizer.UserUsernameIsEmpty);
        RuleFor(user=>user.userName).MinimumLength(5).WithMessage(user=>string.Format(ResourceLocalizer.UserUsernameAlreadyExists,user.userName));
    }
}
