using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Queries.GetById;

public class GetByIdColorQuery : IRequest<GetByIdColorResponse>
{
    public Guid Id { get; set; }

    public class GetByIdColorQueryHandler : IRequestHandler<GetByIdColorQuery, GetByIdColorResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetByIdColorQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdColorResponse> Handle(GetByIdColorQuery request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetByIdAsync(request.Id);

            GetByIdColorResponse response = _mapper.Map<GetByIdColorResponse>(color);

            return response;
        }
    }
}