using ccex_api.Models;

namespace ccex_api.DTOs;

public class ChineseCharacterDTO
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<TradCharacterStubDTO> TradChars { get; set; } = [];
  public ICollection<ChineseCharacterComponentDTO> Components { get; set; } = [];
  public ICollection<ChineseCharacterDerivativeDTO> Derivatives { get; set; } = [];
  public ICollection<ChineseCharacterBasicDTO> Variants { get; set; } = [];
  public int? BaseId { get; set; } = null;
  public ChineseCharacterBasicDTO? Base { get; set; }
  public PinyinBasicDTO? MainPinyin { get; set; }
  public ICollection<PinyinBasicDTO> AllPinyins { get; set; } = [];
  public string Definition { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Frequency { get; set; }

}