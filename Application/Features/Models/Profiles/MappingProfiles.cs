using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Queries.GetAll;
using Application.Features.Models.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreateModelCommand>().ReverseMap();
        CreateMap<Model, CreatedModelResponse>().ReverseMap();

        CreateMap<Model, GetAllModelItemResponse>().ReverseMap();

        CreateMap<Model, DeletedModelResponse>().ReverseMap();

        CreateMap<Model, UpdatedModelResponse>().ReverseMap();
        CreateMap<Model, UpdateModelCommand>().ReverseMap();

        CreateMap<Model, GetByIdModelResponse>().ReverseMap();
    }
}
