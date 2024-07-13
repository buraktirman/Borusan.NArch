using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand : IRequest<CreatedModelResponse>
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
    {
        private readonly IModelRepository _repository;
        private readonly IMapper _mapper;
        public CreateModelCommandHandler(IModelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            Model modelToCreate = _mapper.Map<Model>(request);

            Model createdModel = await _repository.AddAsync(modelToCreate);

            CreatedModelResponse response = _mapper.Map<CreatedModelResponse>(createdModel);

            return response;
        }
    }
}
