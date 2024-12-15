namespace ccex_api.Aggregates;

public class ComponentStub
{
  public string Char { get; set; } = string.Empty;
  public ICollection<string> Pinyin { get; set; } = [];
  public int Frequency { get; set; }
  public string Parent { get; set; } = string.Empty;

}