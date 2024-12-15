using ccex_api.Aggregates;

namespace ccex_api.Init;

public class ChineseCharacterInit
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<TradCharacterStub> TradChars { get; set; } = [];
  public ICollection<ComponentStub> Components { get; set; } = [];
  public ICollection<DerivativeStub> Derivatives { get; set; } = [];
  public ICollection<string> Variants { get; set; } = [];
  public string? Base { get; set; }
  public ICollection<string> PrimaryPinyin { get; set; } = [];
  public ICollection<string> SecondaryPinyin { get; set; } = [];
  public string Definition { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Frequency { get; set; }

}

public class PinyinInit
{
  public int Id { get; set; }
  public string syllable { get; set; } = string.Empty;
  public int toneNumber { get; set; }
  public string syllableWithToneMark { get; set; } = string.Empty;

}