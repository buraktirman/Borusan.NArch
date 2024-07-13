using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetAll;
using Application.Features.Fuels.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Fuels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
        CreateMap<Fuel, CreatedFuelResponse>().ReverseMap();

        CreateMap<Fuel, GetAllFuelItemResponse>().ReverseMap();

        CreateMap<Fuel, DeletedFuelResponse>().ReverseMap();

        CreateMap<Fuel, UpdatedFuelResponse>().ReverseMap();
        CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();

        CreateMap<Fuel, GetByIdFuelResponse>().ReverseMap();
    }
}
