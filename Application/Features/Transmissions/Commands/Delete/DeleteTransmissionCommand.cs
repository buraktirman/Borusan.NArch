using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.Delete;

public class DeleteTransmissionCommand : IRequest<DeletedTransmissionResponse>
{
    public Guid Id { get; set; }

    public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeletedTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTransmissionResponse> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission? transmissionToDelete = await _transmissionRepository.GetByIdAsync(request.Id);

            Transmission deletedTransmission = await _transmissionRepository.DeleteAsync(transmissionToDelete);

            DeletedTransmissionResponse response = _mapper.Map<DeletedTransmissionResponse>(deletedTransmission);

            return response;
        }
    }
}
