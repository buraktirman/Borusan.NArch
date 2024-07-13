using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Create;

public class CreateFuelCommand : IRequest<CreatedFuelResponse>
{
    public string Name { get; set; }

    public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreatedFuelResponse>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<CreatedFuelResponse> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
        {
            Fuel fuelToAdd = _mapper.Map<Fuel>(request);

            Fuel addedFuel = await _fuelRepository.AddAsync(fuelToAdd);

            CreatedFuelResponse response = _mapper.Map<CreatedFuelResponse>(addedFuel);

            return response;
        }
    }
}
