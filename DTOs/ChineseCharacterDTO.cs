using ccex_api.Aggregates;

namespace ccex_api.DTOs;

public class ChineseCharacterDTO
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<TradCharacterStub> TradChars { get; set; } = [];
  public ICollection<ChineseCharacterComponentDTO> Components { get; set; } = [];
  public ICollection<ChineseCharacterDerivativeDTO> Derivatives { get; set; } = [];
  public ICollection<ChineseCharacterBasicDTO> Variants { get; set; } = [];
  public ChineseCharacterBasicDTO? Base { get; set; }
  public ICollection<string> PrimaryPinyin { get; set; } = [];
  public ICollection<string> SecondaryPinyin { get; set; } = [];
  public string Definition { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Frequency { get; set; }

}