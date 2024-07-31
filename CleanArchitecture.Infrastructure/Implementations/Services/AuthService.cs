using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Application.Contracts.Auth.Responses;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application.Resources;
using CleanArchitecture.Common.Enums;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace CleanArchitecture.Infrastructure.Implementations.Services;

public class AuthService(IUnitOfWork unitOfWork, IConfiguration configuration) : IAuthService
{
    public async Task<IResponse<EmptyResponse>> ConfirmEmail(string token, Guid userId)
    {
        var user = await unitOfWork.authRepository.FindById(userId.ToString());

        if (user is null) return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = ErrorCodes.USER_NOT_FOUND, errorMessage = ResourceLocalizer.UserNotFound });

        var response = await unitOfWork.authRepository.ConfirmEmail(token, user);
        if (!response.Succeeded)
        {

        }
        return null;
    }

    public async Task<IResponse<AdminAuthLoginResponse>> Login(LoginRequest request)
    {
        var user = await unitOfWork.authRepository.FindByUsername(request.username);
        if (user is null) return ResponseHelper<AdminAuthLoginResponse>.Failed(new Error { errorKey = ErrorCodes.INVALID_USERNAME_OR_PASSWORD, errorMessage = ResourceLocalizer.UserNotFound });

        var isValid = await unitOfWork.authRepository.CheckUserPsswordAsync(user, request.password);
        if (!isValid) return ResponseHelper<AdminAuthLoginResponse>.Failed(new Error { errorKey = ErrorCodes.INVALID_USERNAME_OR_PASSWORD, errorMessage = ResourceLocalizer.UserNotFound });

        var claims = new Claim[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };
        unitOfWork.Dispose();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:Key")));
        var issuer = configuration.GetValue<string>("JWT:Issuer");
        var audience = configuration.GetValue<string>("JWT:Audience");

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: request.rememberMe ? DateTime.Now.AddYears(1) : DateTime.Now.AddHours(2),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

        var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
        var response = new AdminAuthLoginResponse
        {
            token = tokenAsString,
            validTo = token.ValidTo,
        };

        return ResponseHelper<AdminAuthLoginResponse>.Success(response);
    }

    public async Task SignOut()
    {
        await unitOfWork.authRepository.SignOutAsync();
    }
    public async Task<bool> ValidateToken(string token)
    {
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration.GetValue<string>("JWT:Issuer"),
            ValidAudience = configuration.GetValue<string>("JWT:Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:Key")))
        };


            var tokenHandler = new JwtSecurityTokenHandler();
            var result = await tokenHandler.ValidateTokenAsync(token, validationParameters);

            return result.IsValid;

    }
}
