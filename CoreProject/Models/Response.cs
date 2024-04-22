using System.Text.Json.Serialization;

namespace CoreProject.Models;

public record Response<T>
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("errorMessage")] public string? ErrorMessage { get; set; }
    [JsonPropertyName("result")] public T? Result { get; init; }
}
