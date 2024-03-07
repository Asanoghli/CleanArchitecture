using AutoMapper;
using CleanArchitecture.Application.Contracts.Admin.Users.Requests;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser,AdminCreateUserRequest>().ReverseMap();
        }
    }
}
