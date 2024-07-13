using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.Update;

public class UpdateTransmissionCommand : IRequest<UpdatedTransmissionResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdatedTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTransmissionResponse> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission? transmissionToUpdate = await _transmissionRepository.GetByIdAsync(request.Id);

            transmissionToUpdate = _mapper.Map<Transmission>(request);

            Transmission updatedTransmission = await _transmissionRepository.UpdateAsync(transmissionToUpdate);

            UpdatedTransmissionResponse response = _mapper.Map<UpdatedTransmissionResponse>(updatedTransmission);

            return response;
        }
    }
}
