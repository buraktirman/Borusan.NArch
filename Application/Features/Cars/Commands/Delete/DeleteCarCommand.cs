using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommand : IRequest<DeletedCarResponse>
{
    public Guid Id { get; set; }

    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Car? carToDelete = await _carRepository.GetByIdAsync(request.Id);

            Car deletedCar = await _carRepository.DeleteAsync(carToDelete);

            DeletedCarResponse response = _mapper.Map<DeletedCarResponse>(deletedCar);

            return response;
        }
    }
}
