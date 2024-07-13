using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

// Unit => Fonksiyonda void 
public class CreateBrandCommand : IRequest<CreatedBrandResponse>
{
    // Komutun işlevini yerine getirmesi için gereken argümanlar

    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            // İlgili request ile istediğimiz işlemleri yapabiliriz.

            Brand brand = _mapper.Map<Brand>(request);

            Brand addedBrand = await _brandRepository.AddAsync(brand);

            CreatedBrandResponse response = _mapper.Map<CreatedBrandResponse>(addedBrand);

            return response;
        }
    }
}
