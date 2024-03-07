using CleanArchitecture.Common.Enums;
using CleanArchitecture.Domain.Extensions;
using FluentValidation;

namespace CleanArchitecture.Application.Contracts.Admin.Users.Requests;

public class AdminGetUserRequest
{
    public int userId { get; set; }
    public int age { get; set; }
}
public class AdminGetUserRequestValidator : AbstractValidator<AdminGetUserRequest>
{
    public AdminGetUserRequestValidator()
    {
        RuleFor(prop => prop.userId).NotEmpty()
            .WithMessage(pros => ReturnTypes.EmailAlreadyExists.GetDescription("Asanoghli@gmail.com"))
            .GreaterThan(10).WithMessage(pros => ReturnTypes.EmailAlreadyExists2.GetDescription("12", "15"));

        RuleFor(prop => prop.age).GreaterThan(10)
           .WithMessage(pros => ReturnTypes.EmailAlreadyExists2.GetDescription("Zdarova", "Gela"));
    }
}
