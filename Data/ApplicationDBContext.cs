using ccex_api.Models;
using ccex_api.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace ccex_api.Data;

public class ApplicationDBContext : DbContext
{
  public ApplicationDBContext(DbContextOptions options)
  : base(options)
  {}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.UseHiLo();

    modelBuilder.Entity<ChineseCharacter>()
      .HasMany(e => e.Variants)
      .WithOne(e => e.Base)
      .HasForeignKey(e => e.BaseId);

    modelBuilder.Entity<ChineseCharacter>()
      .OwnsMany(c => c.TradChars, cBuilder => {
        cBuilder.ToJson();
      });

  }

  public DbSet<ChineseCharacter> ChineseCharacter { get; set; } = null!;

  public DbSet<Pinyin> Pinyin { get; set; } = null!;

}