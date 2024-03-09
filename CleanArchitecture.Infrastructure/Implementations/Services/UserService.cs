using AutoMapper;
using CleanArchitecture.Application.Contracts.Admin.Users.Requests;
using CleanArchitecture.Application.Contracts.Admin.Users.Responses;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application.Resources;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Extensions;
using PagedList;
using PagedList.EntityFramework;

namespace CleanArchitecture.Infrastructure.Implementations.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper _mapper) : IUserService
{
    public async Task<IResponse<AdminCreateUserResponse>> CreateUserAsync(AdminCreateUserRequest user)
    {

        var appUser = _mapper.Map<AppUser>(user);

        var result = await unitOfWork.userRepository.CreateAsync(appUser, user.password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.GetResponseErrors();
            return ResponseHelper<AdminCreateUserResponse>.Failed(errors);
        }

        var createUserResponse = new AdminCreateUserResponse();
        createUserResponse.id = appUser.Id;

        return ResponseHelper<AdminCreateUserResponse>.Success(createUserResponse);
    }
    public async Task<IResponse<EmptyResponse>> UpdateUserAsync(AdminUpdateUserRequest user)
    {
        if (user == null) return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = nameof(user), errorMessage = ResourceLocalizer.RequestModelIsNull });

        var findedUser = await unitOfWork.userRepository.FindById(user.id.Value.ToString());

        if (findedUser == null) return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = nameof(user.id), errorMessage = ResourceLocalizer.UserNotFound });

        findedUser = _mapper.Map(user, findedUser);

        var response = await unitOfWork.userRepository.UpdateUser(findedUser);

        if (!response.Succeeded)
        {
            var errors = response.Errors.GetResponseErrors();
            return ResponseHelper<EmptyResponse>.Failed(errors);
        }

        return ResponseHelper<EmptyResponse>.Success();
    }
    public async Task<IResponse<IPagedList<AdminGetAllUsersResponse>>> GetAllUsers(AdminGetAllUsersRequest request)
    {
        var usersQuery = unitOfWork.userRepository.GetAllUsersQuery();

        #region Filters
        if (request != null)
        {
            if (!string.IsNullOrWhiteSpace(request.firstName)) usersQuery = usersQuery.Where(user => user.FirstName.Contains(request.firstName));
            if (!string.IsNullOrWhiteSpace(request.lastName)) usersQuery = usersQuery.Where(user => user.LastName.Contains(request.lastName));
            if (!string.IsNullOrWhiteSpace(request.email)) usersQuery = usersQuery.Where(user => user.Email != null && user.Email.Equals(request.email));
            if (!string.IsNullOrWhiteSpace(request.phoneNumber)) usersQuery = usersQuery.Where(user => user.PhoneNumber != null && user.PhoneNumber.Equals(request.phoneNumber));
            if (request.birthDate.HasValue) usersQuery = usersQuery.Where(user => user.BirthDate != null && user.BirthDate.Value.Equals(request.birthDate.Value));
        }
        #endregion

        var mappedUsersQuery = _mapper.ProjectTo<AdminGetAllUsersResponse>(usersQuery);

        var users = await mappedUsersQuery.ToPagedListAsync(request!.pageNumber, request.pageSize);

        return ResponseHelper<IPagedList<AdminGetAllUsersResponse>>.Success(users);
    }
    public async Task<IResponse<EmptyResponse>> ConfirmEmailAsync(Guid userId, string token)
    {
        var isUserEmpty = userId == Guid.Empty;
        if (isUserEmpty) return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = nameof(userId), errorMessage = ResourceLocalizer.UserIdIsEmpty });

        var user = await unitOfWork.userRepository.FindById(userId.ToString());
        if (user == null) return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = nameof(userId), errorMessage = ResourceLocalizer.UserNotFound });

        var response = await unitOfWork.userRepository.ConfirmEmailAsync(user, token);
        if (!response.Succeeded) return ResponseHelper<EmptyResponse>.Failed(response.Errors.GetResponseErrors());

        return ResponseHelper<EmptyResponse>.Success();
    }
    public async Task<IResponse<string>> GenerateConfirmationToken(Guid userId)
    {
        if (userId == Guid.Empty) return ResponseHelper<string>.Failed(new Error { errorKey = nameof(userId), errorMessage = ResourceLocalizer.UserIdIsEmpty });

        var user = await unitOfWork.userRepository.FindById(userId.ToString());
        if (user == null) return ResponseHelper<string>.Failed(new Error { errorKey = nameof(AppUser.Id), errorMessage = ResourceLocalizer.UserNotFound });

        var token = await unitOfWork.userRepository.GenerateConfirmationToken(user);

        return ResponseHelper<string>.Success(token);
    }
    public async Task<IResponse<EmptyResponse>> ChangePasswordAsync(Guid userId, string oldPassword, string newPassword)
    {
        if (userId == Guid.Empty) return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = nameof(userId), errorMessage = ResourceLocalizer.UserIdIsEmpty });

        var user = await unitOfWork.userRepository.FindById(userId.ToString());
        if (user == null) { return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = nameof(userId), errorMessage = ResourceLocalizer.UserNotFound }); }

        var response = await unitOfWork.userRepository.ChangePasswordAsync(user, oldPassword, newPassword);

        if (!response.Succeeded)
        {
            var errors = response.Errors.GetResponseErrors();
            return ResponseHelper<EmptyResponse>.Failed(errors);
        }

        return ResponseHelper<EmptyResponse>.Success();
    }
}
