namespace ccex_api.DTOs;

public class PinyinDTO
{
  public int Id { get; set; }
  public string Syllable { get; set; } = string.Empty;
  public int ToneNumber { get; set; }
  public string SyllableWithToneMark { get; set; } = string.Empty;
  public ICollection<ChineseCharacterBasicDTO> Chars { get; set; } = [];

}