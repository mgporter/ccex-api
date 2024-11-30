namespace ccex_api.DTOs;

public class PinyinBasicDTO
{
  public int Id { get; set; }
  public string Syllable { get; set; } = string.Empty;
  public int ToneNumber { get; set; }
  public string SyllableWithToneMark { get; set; } = string.Empty;

}