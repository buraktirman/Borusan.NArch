using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.Delete;

public class DeleteColorCommand : IRequest<DeletedColorResponse>
{
    public Guid Id { get; set; }

    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeletedColorResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public DeleteColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<DeletedColorResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            Color? colorToDelete = await _colorRepository.GetByIdAsync(request.Id);
            
            Color deletedColor = await _colorRepository.DeleteAsync(colorToDelete);

            DeletedColorResponse response = _mapper.Map<DeletedColorResponse>(deletedColor);

            return response;
        }
    }
}
