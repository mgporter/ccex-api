using System.ComponentModel.DataAnnotations.Schema;

namespace ccex_api.Models;

public class ChineseCharacter
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<ChineseCharacter> Components { get; set; } = [];
  public ICollection<ChineseCharacter> Derivatives { get; set; } = [];
  public ICollection<ChineseCharacter> Variants { get; set; } = [];
  public int? BaseId { get; set; }
  public ChineseCharacter? Base { get; set; }
  public ICollection<Pinyin> Pinyins { get; set; } = [];
  public string Definition { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int Frequency { get; set; }

}
