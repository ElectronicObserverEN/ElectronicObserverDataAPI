using ElectronicObserverDataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicObserverDataAPI.Database;

public class ApiDbContext : DbContext
{
    public DbSet<EquipmentUpgradeIssueModel> EquipmentUpgradeIssues { get; set; }
    public DbSet<QuestTranslationMissingModel> QuestTranslationMissing { get; set; }

    public string DbPath => Path.Combine(Environment.CurrentDirectory, "ElectronicObserverData.db");
    
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