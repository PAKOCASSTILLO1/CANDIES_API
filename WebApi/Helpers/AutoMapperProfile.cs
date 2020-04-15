using AutoMapper;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserRegisterDto>();

            // Role
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            // Page
            CreateMap<Page, PageDto>();
            CreateMap<PageDto, Page>();

            // UserRole
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();

            // RolePage
            CreateMap<RolePage, RolePageDto>();
            CreateMap<RolePageDto, RolePage>();
        }
    }
}