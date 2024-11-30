using ccex_api.Models;

namespace ccex_api.DTOs;

public class ChineseCharacterComponentDTO
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<ChineseCharacterComponentDTO> Components { get; set; } = [];
  public ICollection<PinyinBasicDTO> Pinyins { get; set; } = [];
  public int Frequency { get; set; }

}