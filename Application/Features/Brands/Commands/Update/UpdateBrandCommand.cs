using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brandToUpdate = await _brandRepository.GetByIdAsync(request.Id);

            if (brandToUpdate == null)
                throw new Exception("Güncellemeye çalıştığınız marka bulunamadı.");
            
            // Güncelleme işlemi burada oluyor.
            // Gönderdiğimiz name, eski brandin içerisine ekleniyor.
            brandToUpdate = _mapper.Map<Brand>(request);

            Brand updatedBrand = await _brandRepository.UpdateAsync(brandToUpdate);

            UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(updatedBrand);

            return response;
        }
    }
}
