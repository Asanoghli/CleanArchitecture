using AutoMapper;
using CleanArchitecture.Application.Contracts.User.Requests;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser,CreateUserRequest>().ReverseMap();
        }
    }
}
