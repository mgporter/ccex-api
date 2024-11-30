using ccex_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ccex_api.Data;

public class ApplicationDBContext : DbContext
{
  public ApplicationDBContext(DbContextOptions options)
  : base(options)
  {}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ChineseCharacter>()
      .HasMany(e => e.Variants)
      .WithOne(e => e.Base)
      .HasForeignKey(e => e.BaseId);
    
  }

  public DbSet<ChineseCharacter> ChineseCharacter { get; set; } = null!;

  public DbSet<Pinyin> Pinyin { get; set; } = null!;

}