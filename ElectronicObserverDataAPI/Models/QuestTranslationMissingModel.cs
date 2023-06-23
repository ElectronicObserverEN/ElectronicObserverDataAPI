using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public record QuestTranslationMissingModel
{
    [JsonPropertyName("software_version")] public string SoftwareVersion { get; set; } = "";

    [JsonPropertyName("data_version")] public int DataVersion { get; set; }

    [JsonPropertyName("api_id")] public int ApiId { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; } = "";

    [JsonPropertyName("description")] public string Desription { get; set; } = "";

    [JsonIgnore] public int Id { get; set; }

    [JsonIgnore] public DateTime AddedOn { get; set; }
}