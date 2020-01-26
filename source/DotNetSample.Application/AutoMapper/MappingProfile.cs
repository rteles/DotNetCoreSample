using System.Collections.Generic;
using AutoMapper;
using DotNetSample.Application.DataTypes.Request;
using DotNetSample.Application.DataTypes.Result;
using DotNetSample.Domain.Entities;

namespace DotNetSample.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResult>();
            // CreateMap<List<User>, List<UserResult>>();
            CreateMap<AddUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}