using Application.Encryption.JWT;
using Application.Hashing;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoggedInResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;

        public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<LoggedInResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = _userRepository.Get(i => i.Email == request.Email);

            if (user is null)
            {
                //Login endpointlerinde genellikle her hata mesajı aynıdır.
                throw new Exception("Login failed.");
            }

            if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash))
                throw new Exception("Login failed.");

            return new() { Token = _tokenHelper.CreateToken(user) };
        }
    }
}
