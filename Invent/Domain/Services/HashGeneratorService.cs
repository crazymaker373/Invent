using System.Text;

namespace Domain.Services;

public class HashGeneratorService : IHashGeneratorService{
    public string GenerateHash(string LocationName = "NUL", int length = 6){
        var hash = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVW1234567890ß";
        var r = new Random();
        StringBuilder sb = new StringBuilder();
        sb.Append(LocationName);
        for (int i = 0; i < length; i++){
            sb.Append(hash[r.Next(0, hash.Length)]);
        }

        return sb.ToString();
    }
}