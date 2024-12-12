using Microsoft.EntityFrameworkCore;

namespace ccex_api.Models;

// [Index(nameof(Char), IsUnique = true)]
public class TradCharacterStub
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public int SimpCharId { get; set; }
  public ChineseCharacter SimpChar { get; set; } = null!;
  public ICollection<Pinyin> Pinyin { get; set; } = [];
  public string? Definition { get; set; } = null;
  public string? Description { get; set; } = null;

}
