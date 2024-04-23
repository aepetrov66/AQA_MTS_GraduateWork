using CoreProject.Models.Enums;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CoreProject.Models;

public record Project
{
    public TestDataType testDataType { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("code")] public string? Code { get; init; }
    [JsonPropertyName("counts")] public Counts? Counts { get; set; }
}
