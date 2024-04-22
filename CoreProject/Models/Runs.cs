using System.Text.Json.Serialization;

namespace CoreProject.Models;

public record Runs
{
    [JsonPropertyName("total")] public int? Total { get; set; }
    [JsonPropertyName("active")] public int? Active { get; set; }
}
