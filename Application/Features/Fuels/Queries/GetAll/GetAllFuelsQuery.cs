using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries.GetAll;

public class GetAllFuelsQuery : IRequest<List<GetAllFuelItemResponse>>
{
    public class GetAllFuelsQueryHandler : IRequestHandler<GetAllFuelsQuery, List<GetAllFuelItemResponse>>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public GetAllFuelsQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllFuelItemResponse>> Handle(GetAllFuelsQuery request, CancellationToken cancellationToken)
        {
            List<Fuel> fuels = await _fuelRepository.GetAllAsync();

            List<GetAllFuelItemResponse> response = _mapper.Map<List<GetAllFuelItemResponse>>(fuels);

            return response;
        }
    }
}
