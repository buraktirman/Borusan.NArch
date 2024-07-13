using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Queries.GetAll;

public class GetAllModelsQuery : IRequest<List<GetAllModelItemResponse>>
{
    public class GetAllModelsQueryHandler : IRequestHandler<GetAllModelsQuery, List<GetAllModelItemResponse>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetAllModelsQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllModelItemResponse>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
        {
            List<Model> models = await _modelRepository.GetAllAsync();

            List<GetAllModelItemResponse> response = _mapper.Map<List<GetAllModelItemResponse>>(models);

            return response;
        }
    }
}
