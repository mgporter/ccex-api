namespace ccex_api.DTOs;

public class ChineseCharacterDTO
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<ChineseCharacterComponentDTO> Components { get; set; } = [];
  public ICollection<ChineseCharacterComponentDTO> Derivatives { get; set; } = [];
  public ICollection<ChineseCharacterBasicDTO> Variants { get; set; } = [];
  public int? BaseId { get; set; }
  public ChineseCharacterBasicDTO? Base { get; set; }
  public ICollection<PinyinBasicDTO> Pinyins { get; set; } = [];
  public string Definition { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Frequency { get; set; }

}