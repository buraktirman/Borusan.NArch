using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Update;

public class UpdateFuelCommand : IRequest<UpdatedFuelResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdatedFuelResponse>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedFuelResponse> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
        {
            Fuel? fuelToUpdate = await _fuelRepository.GetByIdAsync(request.Id);

            fuelToUpdate = _mapper.Map<Fuel>(request);

            Fuel updatedFuel = await _fuelRepository.UpdateAsync(fuelToUpdate);

            UpdatedFuelResponse response = _mapper.Map<UpdatedFuelResponse>(updatedFuel);

            return response;
        }
    }
}
