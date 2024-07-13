using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.Update;

public class UpdateColorCommand : IRequest<UpdatedColorResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdatedColorResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedColorResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            Color? colorToUpdate = await _colorRepository.GetByIdAsync(request.Id);

            colorToUpdate = _mapper.Map<Color>(request);

            Color updatedColor = await _colorRepository.UpdateAsync(colorToUpdate);

            UpdatedColorResponse response = _mapper.Map<UpdatedColorResponse>(updatedColor);

            return response;
        }
    }
}
