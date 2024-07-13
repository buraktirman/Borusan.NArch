using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries.GetById;

public class GetByIdFuelQuery : IRequest<GetByIdFuelResponse>
{
    public Guid Id { get; set; }

    public class GetByIdFuelQueryHandler : IRequestHandler<GetByIdFuelQuery, GetByIdFuelResponse>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public GetByIdFuelQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdFuelResponse> Handle(GetByIdFuelQuery request, CancellationToken cancellationToken)
        {
            Fuel? fuel = await _fuelRepository.GetByIdAsync(request.Id);

            GetByIdFuelResponse response = _mapper.Map<GetByIdFuelResponse>(fuel);

            return response;
        }
    }
}
