using System.Text.Json.Serialization;

namespace ElectronicObserverDataAPI.Models;

public record EquipmentUpgradeIssueModel
{
    [JsonPropertyName("software_version")] public string SoftwareVersion { get; set; } = "";

    [JsonPropertyName("data_version")] public int DataVersion { get; set; }
    
    [JsonPropertyName("expected")] public List<int> ExpectedUpgrades { get; set; } = new();

    [JsonPropertyName("actual")] public List<int> ActualUpgrades { get; set; } = new();

    [JsonPropertyName("day")] public DayOfWeek Day { get; set; }

    [JsonPropertyName("helperId")] public int HelperId { get; set; }

    [JsonPropertyName("state")] public IssueState IssueState { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonIgnore] public DateTime AddedOn { get; set; }

    public virtual bool Equals(EquipmentUpgradeIssueModel? other)
    {
        if (other is null) return false;

        if (!other.ExpectedUpgrades.SequenceEqual(ExpectedUpgrades)) return false;
        if (!other.ActualUpgrades.SequenceEqual(ActualUpgrades)) return false;
        if (other.Day != Day) return false;
        if (other.HelperId != HelperId) return false;

        return true;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(ExpectedUpgrades);
        hashCode.Add(ActualUpgrades);
        hashCode.Add((int)Day);
        hashCode.Add(HelperId);

        return hashCode.ToHashCode();
    }
}