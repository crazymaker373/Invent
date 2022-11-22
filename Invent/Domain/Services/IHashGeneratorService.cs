using System.Text;
using Microsoft.Extensions.Primitives;

namespace Domain.Services;

public interface IHashGeneratorService{
    public string GenerateHash(string LoactionName = "NUL", int length = 6);
}