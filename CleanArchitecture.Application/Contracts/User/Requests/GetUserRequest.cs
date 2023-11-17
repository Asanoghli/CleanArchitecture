using CleanArchitecture.Common.Enums;
using CleanArchitecture.Domain.Extensions;
using FluentValidation;

namespace CleanArchitecture.Application.Contracts.User.Requests;

public class GetUserRequest
{
    public int userId { get; set; }
    public int age { get; set; }
}
public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
{
    public GetUserRequestValidator()
    {
        RuleFor(prop => prop.userId).NotEmpty()
            .WithMessage(pros => ReturnTypes.EmailAlreadyExists.GetDescription("Asanoghli@gmail.com"))
            .GreaterThan(10).WithMessage(pros => ReturnTypes.EmailAlreadyExists2.GetDescription("12", "15"));

        RuleFor(prop => prop.age).GreaterThan(10)
           .WithMessage(pros => ReturnTypes.EmailAlreadyExists2.GetDescription("Zdarova","Gela"));
    }
}
