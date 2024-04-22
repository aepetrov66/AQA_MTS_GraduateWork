using System.Text.Json.Serialization;

namespace CoreProject.Models;

public record Projects
{
    [JsonPropertyName("total")] public int? Total { get; set; }
    [JsonPropertyName("filtered")] public int? Filtered { get; set; }
    [JsonPropertyName("count")] public int? Count { get; set; }
    [JsonPropertyName("entities")] public List<Project>? Entities { get; set; }
}
