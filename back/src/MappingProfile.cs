using AutoMapper;
using OpenCRM.Dtos;
using OpenCRM.Entities;

namespace OpenCRM;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
    }
}