using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.Delete;

public class DeleteFuelCommand : IRequest<DeletedFuelResponse>
{
    public Guid Id { get; set; }

    public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeletedFuelResponse>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public DeleteFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<DeletedFuelResponse> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
        {
            Fuel? fuelToDelete = await _fuelRepository.GetByIdAsync(request.Id);

            Fuel deletedFuel = await _fuelRepository.DeleteAsync(fuelToDelete);

            DeletedFuelResponse response = _mapper.Map<DeletedFuelResponse>(deletedFuel);

            return response;
        }
    }
}