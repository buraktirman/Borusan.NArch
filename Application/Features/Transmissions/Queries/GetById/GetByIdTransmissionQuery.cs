using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Queries.GetById;

public class GetByIdTransmissionQuery : IRequest<GetByIdTransmissionResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTransmissionQueryHandler : IRequestHandler<GetByIdTransmissionQuery, GetByIdTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetByIdTransmissionQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTransmissionResponse> Handle(GetByIdTransmissionQuery request, CancellationToken cancellationToken)
        {
            Transmission? transmission = await _transmissionRepository.GetByIdAsync(request.Id);

            GetByIdTransmissionResponse response = _mapper.Map<GetByIdTransmissionResponse>(transmission);

            return response;
        }
    }
}
