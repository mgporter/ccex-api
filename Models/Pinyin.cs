using Microsoft.EntityFrameworkCore;

namespace ccex_api.Models;

[Index(nameof(Syllable), nameof(ToneNumber), IsUnique = true)]
[Index(nameof(SyllableWithToneMark), IsUnique = true)]
public class Pinyin
{
  public int Id { get; set; }
  public string Syllable { get; set; } = string.Empty;
  public int ToneNumber { get; set; }
  public string SyllableWithToneMark { get; set; } = string.Empty;
  public ICollection<ChineseCharacter> Chars { get; set; } = [];

}