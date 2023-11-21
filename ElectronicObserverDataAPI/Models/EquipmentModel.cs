using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public record EquipmentModel
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("equipmentId")] public int EquipmentId { get; init; }

	[JsonPropertyName("level")] public int Level { get; init; }

	public virtual bool Equals(EquipmentModel? other)
	{
		if (other is null) return false;

		if (other.EquipmentId != EquipmentId) return false;
		if (other.Level != Level) return false;

		return true;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(EquipmentId, Level);
	}
}
