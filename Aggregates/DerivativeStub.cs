namespace ccex_api.Aggregates;

public class DerivativeStub
{
  public string Char { get; set; } = string.Empty;
  public ICollection<string> Pinyin { get; set; } = [];
  public int Frequency { get; set; }

}