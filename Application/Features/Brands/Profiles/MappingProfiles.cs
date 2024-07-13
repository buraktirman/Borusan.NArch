using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBrandCommand, Brand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();

        CreateMap<Brand, GetAllBrandItemResponse>().ReverseMap();

        CreateMap<Brand, DeletedBrandResponse>().ReverseMap();

        CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();

        CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
    }
}
