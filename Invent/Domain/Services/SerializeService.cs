using System.Text.Json;
using System.Text.Json.Serialization;

namespace Domain.Services;

public class SerializeService {
    public static string Serialize<T>(T obj) => JsonSerializer.Serialize(obj, new JsonSerializerOptions {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    });

    public static T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    })!;
}