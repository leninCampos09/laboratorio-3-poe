using System.Security.Cryptography;
using System.Text;

namespace laboratorio_3_poe.Services;

public static class PasswordHasher
{
    public static byte[] Hash(string password) => SHA256.HashData(Encoding.UTF8.GetBytes(password));

    public static bool Verify(string password, byte[] expectedHash)
    {
        var actualHash = Hash(password);
        return expectedHash.Length == actualHash.Length && CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }
}
