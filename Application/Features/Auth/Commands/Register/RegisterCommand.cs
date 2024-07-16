using Application.Hashing;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            User userToRegister = _mapper.Map<User>(request);

            byte[] passwordSalt, passwordHash;

            HashingHelper.CreatePasswordHash(request.Password, out passwordSalt, out passwordHash);

            userToRegister.PasswordSalt = passwordSalt;
            userToRegister.PasswordHash = passwordHash;

            await _userRepository.AddAsync(userToRegister);

            RegisteredResponse response = new() { Token = "" };

            return response;
        }
    }
}
