using Microsoft.EntityFrameworkCore;

namespace ccex_api.Models;

[Index(nameof(Char), IsUnique = true)]
public class ChineseCharacter
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<TradCharacterStub> TradChars { get; set; } = [];
  public ICollection<ChineseCharacter> Components { get; set; } = [];
  public ICollection<ChineseCharacter> Derivatives { get; set; } = [];
  public ICollection<ChineseCharacter> Variants { get; set; } = [];
  public int? BaseId { get; set; } = null;
  public ChineseCharacter? Base { get; set; }
  public Pinyin? MainPinyin { get; set; }
  public int? MainPinyinId { get; set; }
  public ICollection<Pinyin> AllPinyin { get; set; } = [];
  public string Definition { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Frequency { get; set; }

}
