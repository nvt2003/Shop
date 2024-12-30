

using AutoMapper;
using BusinessObjects.DTOs;
using BusinessObjects.Models;

namespace BusinessObjects
{
    public class MyMappingProfiles:Profile
    {
        public MyMappingProfiles()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<RegisterRequest, User>();
        }
    }
}
