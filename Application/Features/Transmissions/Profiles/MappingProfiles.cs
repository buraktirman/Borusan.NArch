using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries.GetAll;
using Application.Features.Transmissions.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Transmissions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
        CreateMap<Transmission, CreatedTransmissionResponse>().ReverseMap();

        CreateMap<Transmission, GetAllTransmissionItemResponse>().ReverseMap();

        CreateMap<Transmission, DeletedTransmissionResponse>().ReverseMap();

        CreateMap<Transmission, UpdatedTransmissionResponse>().ReverseMap();
        CreateMap<Transmission, UpdateTransmissionCommand>().ReverseMap();

        CreateMap<Transmission, GetByIdTransmissionResponse>().ReverseMap();
    }
}
