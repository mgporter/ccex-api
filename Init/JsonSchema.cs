namespace ccex_api.Init;

public class ChineseCharacterInit
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<TradCharacterStubInit> TradChars { get; set; } = [];
  public ICollection<string> Components { get; set; } = [];
  public ICollection<string> Derivatives { get; set; } = [];
  public ICollection<string> Variants { get; set; } = [];
  public string? Base { get; set; }
  public ICollection<string> PrimaryPinyin { get; set; } = [];
  public ICollection<string> SecondaryPinyin { get; set; } = [];
  public string Definition { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Frequency { get; set; }

}

public class TradCharacterStubInit
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<string> Pinyin { get; set; } = [];
  public string? Definition { get; set; } = string.Empty;
  public string? Description { get; set; } = string.Empty;
}

public class PinyinInit
{
  public int Id { get; set; }
  public string syllable { get; set; } = string.Empty;
  public int toneNumber { get; set; }
  public string syllableWithToneMark { get; set; } = string.Empty;

}