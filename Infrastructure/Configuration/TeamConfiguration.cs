
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
  public void Configure(EntityTypeBuilder<Team> builder)
  {

    builder.HasKey(e => e.Id).HasName("PRIMARY");

    builder.ToTable("team");

    builder.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

    builder.Property(e => e.Id).HasColumnName("id");
    builder.Property(e => e.Name)
        .HasMaxLength(50)
        .HasColumnName("name");

    builder.HasMany(p => p.Drivers).WithMany(p => p.Teams)
    .UsingEntity<TeamDriver>(
      j => j
        .HasOne(pt => pt.Driver)
        .WithMany(t => t.TeamDrivers)
        .HasForeignKey(pt => pt.IdDriver),
      j => j
        .HasOne(pt => pt.Team)
        .WithMany(t => t.TeamDrivers)
        .HasForeignKey(pt => pt.IdTeam),
      j =>
        {
          j.HasKey(t => new { t.IdDriver, t.IdTeam });
            j.ToTable("teamdriver");
        });

  }
}