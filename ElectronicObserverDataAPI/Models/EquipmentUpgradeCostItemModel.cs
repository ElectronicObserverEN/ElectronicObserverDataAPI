using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public class EquipmentUpgradeCostItemModel
{
    /// <summary>
    /// Id of the item
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Number of this equipment required
    /// </summary>
    [JsonPropertyName("eq_count")]
    public int Count { get; set; }
}
