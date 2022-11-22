using System.Text;
using Microsoft.Extensions.Primitives;

namespace Domain.Services;

public interface IHashGeneratorService{
    public Task<string> GenerateHashAsync(string LoactionName = "NUL", int length = 6);
}