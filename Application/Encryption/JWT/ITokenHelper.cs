using Domain.Entities;

namespace Application.Encryption.JWT;

public interface ITokenHelper
{
    string CreateToken(User user);
}
