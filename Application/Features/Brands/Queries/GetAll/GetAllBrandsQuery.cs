using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetAll;

public class GetAllBrandsQuery : IRequest<List<GetAllBrandItemResponse>>
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<GetAllBrandItemResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetAllBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllBrandItemResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            List<Brand> brands = await _brandRepository.GetAllAsync();

            List<GetAllBrandItemResponse> response = _mapper.Map<List<GetAllBrandItemResponse>>(brands);

            return response;
        }
    }
}
