using ccex_api.Models;

namespace ccex_api.DTOs;

public class ChineseCharacterBasicDTO
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public int Frequency { get; set; }

}