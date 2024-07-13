using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Delete;

public class DeleteModelCommand : IRequest<DeletedModelResponse>
{
    public Guid Id { get; set; }

    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeletedModelResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<DeletedModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            Model? modelToDelete = await _modelRepository.GetByIdAsync(request.Id);

            Model deletedModel = await _modelRepository.DeleteAsync(modelToDelete);

            DeletedModelResponse response = _mapper.Map<DeletedModelResponse>(deletedModel);

            return response;
        }
    }
}
