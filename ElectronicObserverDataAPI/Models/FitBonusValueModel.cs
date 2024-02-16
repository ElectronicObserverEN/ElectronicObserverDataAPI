using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public record FitBonusValueModel
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("houg")] public int Firepower { get; init; }

	[JsonPropertyName("raig")] public int Torpedo { get; init; }

	[JsonPropertyName("tyku")] public int AntiAir { get; init; }

	[JsonPropertyName("souk")] public int Armor { get; init; }

	[JsonPropertyName("kaih")] public int Evasion { get; init; }

	[JsonPropertyName("tais")] public int ASW { get; init; }

	[JsonPropertyName("saku")] public int LOS { get; init; }

	[JsonPropertyName("houm")] public int Accuracy { get; init; }

	[JsonPropertyName("leng")] public int Range { get; init; }

    [JsonPropertyName("baku")] public int Bombing { get; set; }
}
