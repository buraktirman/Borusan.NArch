using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommand : IRequest<CreatedColorResponse>
{
    public string Name { get; set; }

    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreatedColorResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<CreatedColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            Color colorToAdd = _mapper.Map<Color>(request);

            Color addedColor = await _colorRepository.AddAsync(colorToAdd);

            CreatedColorResponse response = _mapper.Map<CreatedColorResponse>(addedColor);

            return response;
        }
    }
}
