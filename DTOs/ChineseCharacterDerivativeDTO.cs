namespace ccex_api.DTOs;

public class ChineseCharacterDerivativeDTO
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<ChineseCharacterDerivativeDTO> Derivatives { get; set; } = [];
  public PinyinBasicDTO? MainPinyin { get; set; }
  public ICollection<PinyinBasicDTO> AllPinyins { get; set; } = [];
  public int Frequency { get; set; }

}