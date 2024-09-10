using ElectronicObserverDataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicObserverDataAPI.Database;

public class ApiDbContext : DbContext
{
    // dotnet ef migrations add <name>
    public DbSet<EquipmentUpgradeIssueModel> EquipmentUpgradeIssues { get; set; }
    public DbSet<EquipmentUpgradeCostIssueModel> EquipmentUpgradeCostIssues { get; set; }
    public DbSet<QuestTranslationMissingModel> QuestTranslationMissing { get; set; }
    public DbSet<FitBonusIssueModel> FitBonusIssues { get; set; }
    public DbSet<SoftwareIssueModel> SoftwareIssues { get; set; }

    private string DbPath => Path.Combine("Data", "ElectronicObserverData.db");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EquipmentUpgradeIssueModel>()
            .Property(issue => issue.ExpectedUpgrades)
            .HasConversion(
                id => string.Join(',', id),
                dbString => dbString
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());

        modelBuilder.Entity<EquipmentUpgradeIssueModel>()
            .Property(issue => issue.ActualUpgrades)
            .HasConversion(
                id => string.Join(',', id),
                dbString => dbString
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
    }
}