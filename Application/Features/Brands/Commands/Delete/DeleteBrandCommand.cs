using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand : IRequest<DeletedBrandResponse>
{
    public Guid Id { get; set; }

    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brandToDelete = await _brandRepository.GetByIdAsync(request.Id);

            Brand deletedBrand = await _brandRepository.DeleteAsync(brandToDelete);

            DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(deletedBrand);

            return response;
        }
    }
}
