using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Queries.GetAll;

public class GetAllTransmissionsQuery : IRequest<List<GetAllTransmissionItemResponse>>
{
    public class GetAllTransmissionsQueryHandler : IRequestHandler<GetAllTransmissionsQuery, List<GetAllTransmissionItemResponse>>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetAllTransmissionsQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllTransmissionItemResponse>> Handle(GetAllTransmissionsQuery request, CancellationToken cancellationToken)
        {
            List<Transmission> transmissions = await _transmissionRepository.GetAllAsync();

            List<GetAllTransmissionItemResponse> response = _mapper.Map<List<GetAllTransmissionItemResponse>>(transmissions);

            return response;
        }
    }
}
