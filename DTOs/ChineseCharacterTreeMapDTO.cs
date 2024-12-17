using ccex_api.Aggregates;

namespace ccex_api.DTOs;

public class ChineseCharacterTreeMapDTO
{
  public int Id { get; set; }
  public string Char { get; set; } = string.Empty;
  public ICollection<ComponentStub> Components { get; set; } = [];
  public ICollection<DerivativeStub> Derivatives { get; set; } = [];
  public ICollection<string> PrimaryPinyin { get; set; } = [];
  public int Frequency { get; set; }

  public ChineseCharacterTreeMapDTO(
    int Id, 
    string Char,
    ICollection<ComponentStub> Components,
    ICollection<DerivativeStub> Derivatives,
    ICollection<string> PrimaryPinyin,
    int Frequency
  )
  {
    this.Id = Id;
    this.Char = Char;
    this.Components = Components;
    this.Derivatives = Derivatives;
    this.PrimaryPinyin = PrimaryPinyin;
    this.Frequency = Frequency;
  }

}