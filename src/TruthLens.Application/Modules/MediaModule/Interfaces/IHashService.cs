namespace TruthLens.Application.Modules.MediaModule.Interfaces;

public interface IHashService
{
    string ComputeHash(Stream stream);
}