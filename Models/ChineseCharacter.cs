using Microsoft.EntityFrameworkCore;
using ccex_api.Aggregates;

namespace ccex_api.Models;

[Index(nameof(Char), IsUnique = true)]
public class ChineseCharacter
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<TradCharacterStub> TradChars { get; set; } = [];
  public ICollection<ComponentStub> Components { get; set; } = [];

  
  public ICollection<DerivativeStub> Derivatives { get; set; } = [];
  public ICollection<ChineseCharacter> Variants { get; set; } = [];
  public int? BaseId { get; set; } = null;
  public ChineseCharacter? Base { get; set; }
  public ICollection<string> PrimaryPinyin { get; set; } = [];
  public ICollection<string> SecondaryPinyin { get; set; } = [];
  public string Definition { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Frequency { get; set; }

}
