using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public record SoftwareIssueModel
{
    [JsonPropertyName("softwareVersion")] public string SoftwareVersion { get; set; } = "";
    
    [JsonPropertyName("exception")] public required SoftwareExceptionModel Exception { get; set; }

    [JsonPropertyName("state")] public IssueState IssueState { get; set; }

    [JsonIgnore] public int Id { get; set; }

    [JsonIgnore] public DateTime AddedOn { get; set; }
}