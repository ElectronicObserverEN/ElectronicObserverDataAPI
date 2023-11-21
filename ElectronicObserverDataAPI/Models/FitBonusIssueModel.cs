using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public record FitBonusIssueModel
{
	[JsonPropertyName("software_version")] public string SoftwareVersion { get; set; } = "";

	[JsonPropertyName("data_version")] public int DataVersion { get; set; }

	[JsonPropertyName("expected")] public FitBonusValueModel ExpectedBonus { get; set; } = new();

	[JsonPropertyName("actual")] public FitBonusValueModel ActualBonus { get; set; } = new();

	[JsonPropertyName("ship")] public ShipModel Ship { get; set; } = new();

	[JsonPropertyName("equipments")] public List<EquipmentModel> Equipments { get; set; } = new();

    [JsonPropertyName("state")] public IssueState IssueState { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonIgnore] public DateTime AddedOn { get; set; }
}
