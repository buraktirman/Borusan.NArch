using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommand : IRequest<UpdatedCarResponse>
{
    public Guid Id { get; set; }
    public Guid ModelId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public Guid ColorId { get; set; }
    public SaleState SaleState { get; set; }
    public string Plate { get; set; }
    public int ModelYear { get; set; }
    public long Kilometer { get; set; }

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car? carToUpdate = await _carRepository.GetByIdAsync(request.Id);

            carToUpdate = _mapper.Map<Car>(request);

            Car updatedCar = await _carRepository.UpdateAsync(carToUpdate);

            UpdatedCarResponse response = _mapper.Map<UpdatedCarResponse>(updatedCar);

            return response;
        }
    }
}
