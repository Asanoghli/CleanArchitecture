using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Application.Contracts.Auth.Responses;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application.Resources;
using CleanArchitecture.Common.Enums;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;
using CleanArchitecture.Infrastructure.Authorization;
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
        var properties = typeof(AlphaSoftAdminPermissions).GetFields();

        var user = await unitOfWork.authRepository.FindByUsername(request.username);
        if (user is null) return ResponseHelper<AdminAuthLoginResponse>.Failed(new Error { errorKey = ErrorCodes.INVALID_USERNAME_OR_PASSWORD, errorMessage = ResourceLocalizer.UserNotFound });

        var isValid = await unitOfWork.authRepository.CheckUserPsswordAsync(user, request.password);
        if (!isValid) return ResponseHelper<AdminAuthLoginResponse>.Failed(new Error { errorKey = ErrorCodes.INVALID_USERNAME_OR_PASSWORD, errorMessage = ResourceLocalizer.UserNotFound });

        // Get Role And User Claims
        var userRoles = await unitOfWork.userRepository.GetUserRolesAsync(user);
        var roleClaims = await GetRoleClaims(userRoles);
        var userClaims = await unitOfWork.userRepository.GetUserClaims(user);
        var permissions = await GetPermissions(roleClaims, userClaims);

        unitOfWork.Dispose();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:Key")));
        var issuer = configuration.GetValue<string>("JWT:Issuer");
        var audience = configuration.GetValue<string>("JWT:Audience");

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: permissions,
            expires: DateTime.Now.AddHours(1),
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


    #region Private Methods
    private async Task<IList<Claim>> GetRoleClaims(IList<string> roles)
    {
        var roleClaims = new List<Claim>();
        for (int i = 0; i < roles.Count; i++)
        {
            var role = await unitOfWork.rolesRepository.FindRoleByName(roles[i]);
            var claims = await unitOfWork.rolesRepository.GetRoleClaims(role);
            if(claims != null)
                roleClaims.AddRange(claims);
        }

        return roleClaims;
    }
    private async Task<Claim[]> GetPermissions(IList<Claim> roleClaims, IList<Claim> userClaims)
    {
        var permissionsCount = roleClaims.Count + userClaims.Count;
        var permissions = new Claim[permissionsCount];

        for (int i = 0; i < roleClaims.Count; i++)
        {
            permissions[i] = roleClaims[i];
        }
        for (int i = roleClaims.Count,k=0;k < userClaims.Count; i++,k++)
        {
            permissions[i] = roleClaims[k];
        }

        return permissions;
    }
    #endregion
}
