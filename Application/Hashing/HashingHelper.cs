using System.Security.Cryptography;
using System.Text;

namespace Application.Hashing;

public static class HashingHelper
{
    public static void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
    {
        using HMACSHA512 hmac = new();
        //Key -> Her üretildiğinde random üretilen bir yapı
        passwordSalt = hmac.Key;

        //UTF8 formatı ile byte karşılığını gönderdik
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
    {
        using HMACSHA512 hmac = new(passwordSalt); // Geçerli salt ile bir şifreleyici
        byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Geçerli salt ile yeni gelen şifreyi hashledim

        return hash.SequenceEqual(passwordHash);
    }
}
