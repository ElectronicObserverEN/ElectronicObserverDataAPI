using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public record ShipModel
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("shipId")] public int ShipId { get; init; }

	[JsonPropertyName("level")] public int Level { get; init; }

	[JsonPropertyName("firepower")] public int Firepower { get; init; }

	[JsonPropertyName("torpedo")] public int Torpedo { get; init; }

	[JsonPropertyName("antiAir")] public int AntiAir { get; init; }

	[JsonPropertyName("armor")] public int Armor { get; init; }

	[JsonPropertyName("evasion")] public int Evasion { get; init; }

	[JsonPropertyName("asw")] public int ASW { get; init; }

	[JsonPropertyName("los")] public int LOS { get; init; }

	[JsonPropertyName("accuracy")] public int Accuracy { get; init; }

	[JsonPropertyName("range")] public int Range { get; init; }

	public bool IsSameShip(ShipModel? otherModel)
	{
		if (otherModel is null) return false;

		if (ShipId != otherModel.ShipId) return false;
		if (Level != otherModel.Level) return false;

		return true;
	}
}
