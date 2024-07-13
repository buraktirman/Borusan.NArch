using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetAll;

public class GetAllCarsQuery : IRequest<List<GetAllCarItemResponse>>
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<GetAllCarItemResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCarItemResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllAsync();

            List<GetAllCarItemResponse> response = _mapper.Map<List<GetAllCarItemResponse>>(cars);

            return response;
        }
    }
}
