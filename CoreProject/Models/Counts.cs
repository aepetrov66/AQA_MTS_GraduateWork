using System.Text;
using System.Text.Json.Serialization;

namespace CoreProject.Models;

public record Counts
{
    [JsonPropertyName("cases")] public int? Cases { get; set; }
    [JsonPropertyName("suites")] public int? Suites { get; set; }
    [JsonPropertyName("milestones")] public int? Milestones { get; set; }
    [JsonPropertyName("runs")] public Runs? Runs { get; set; }
    [JsonPropertyName("defects")] public Defects? Defects { get; set; }

}
