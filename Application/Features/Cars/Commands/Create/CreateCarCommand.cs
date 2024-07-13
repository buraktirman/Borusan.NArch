using Application.Features.Brands.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand : IRequest<CreatedCarResponse>
{
    public Guid ModelId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public Guid ColorId { get; set; }
    public SaleState SaleState { get; set; }
    public string Plate { get; set; }
    public int ModelYear { get; set; }
    public long Kilometer { get; set; }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);

            Car addedCar = await _carRepository.AddAsync(car);

            CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(addedCar);

            return response;
        }
    }
}
