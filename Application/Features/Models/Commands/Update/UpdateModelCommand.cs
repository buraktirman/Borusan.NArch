using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommand : IRequest<UpdatedModelResponse>
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdatedModelResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            Model? modelToUpdate = await _modelRepository.GetByIdAsync(request.Id);

            modelToUpdate = _mapper.Map<Model>(request);

            Model updatedModel = await _modelRepository.UpdateAsync(modelToUpdate);

            UpdatedModelResponse response = _mapper.Map<UpdatedModelResponse>(updatedModel);

            return response;
        }
    }
}
