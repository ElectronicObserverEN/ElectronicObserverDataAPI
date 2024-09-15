using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ElectronicObserverDataAPI.Models;

[PrimaryKey(nameof(EoApiId))]
public class EquipmentUpgradeCostItemModel
{
    /// <summary>
    /// Database Id
    /// </summary>
    [JsonIgnore]
    public int EoApiId { get; set; }

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
