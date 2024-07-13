using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.Create;

public class CreateTransmissionCommand : IRequest<CreatedTransmissionResponse>
{
    public string Name { get; set; }

    public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreatedTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<CreatedTransmissionResponse> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission transmissionToAdd = _mapper.Map<Transmission>(request); 

            Transmission addedTransmission = await _transmissionRepository.AddAsync(transmissionToAdd);

            CreatedTransmissionResponse response = _mapper.Map<CreatedTransmissionResponse>(addedTransmission);

            return response;
        }
    }
}
