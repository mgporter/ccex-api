using ccex_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ccex_api.Data;

public class ApplicationDBContext : DbContext
{
  public ApplicationDBContext(DbContextOptions options)
  : base(options)
  {}

  public DbSet<ChineseCharacter> ChineseCharacter { get; set; } = null!;

  public DbSet<Pinyin> Pinyin { get; set; } = null!;

}