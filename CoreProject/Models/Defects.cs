using System.Text.Json.Serialization;

namespace CoreProject.Models;

public record Defects
{
    [JsonPropertyName("total")] public int? Total { get; set; }
    [JsonPropertyName("open")] public int? Open { get; set; }
}
