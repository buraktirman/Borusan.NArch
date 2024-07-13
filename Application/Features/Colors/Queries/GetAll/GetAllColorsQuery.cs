using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Queries.GetAll;

public class GetAllColorsQuery : IRequest<List<GetAllColorItemResponse>>
{
    public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQuery, List<GetAllColorItemResponse>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetAllColorsQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllColorItemResponse>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
        {
            List<Color> colors = await _colorRepository.GetAllAsync();

            List<GetAllColorItemResponse> response = _mapper.Map<List<GetAllColorItemResponse>>(colors);

            return response;
        }
    }
}
