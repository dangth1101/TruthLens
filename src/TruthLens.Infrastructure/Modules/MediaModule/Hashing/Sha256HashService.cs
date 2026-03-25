using System.Security.Cryptography;
using TruthLens.Application.Modules.MediaModule.Interfaces;

namespace TruthLens.Infrastructure.Modules.MediaModule.Hashing;

public class Sha256HashService : IHashService
{
    public string ComputeHash(Stream stream)
    {
        byte[] hashBytes = SHA256.HashData(stream);
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }
}