using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Auth.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, RegisterCommand>().ReverseMap();
    }
}
