using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public record SoftwareExceptionModel
{
    [JsonIgnore] public int Id { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; } = "";

    [JsonPropertyName("message")] public string Message { get; set; } = "";

    [JsonPropertyName("stackTrace")] public string StackTrace { get; set; } = "";

    [JsonPropertyName("innerExceptions")] public List<SoftwareExceptionModel> InnerExceptions { get; set; } = [];
}