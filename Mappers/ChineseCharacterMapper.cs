using ccex_api.DTOs;
using ccex_api.Models;
using Npgsql.Replication;

namespace ccex_api.Mappers;

public static class ChineseCharacterMapper
{

  public static ChineseCharacterBasicDTO ToBasicDTO(this ChineseCharacter cchar)
  {
    return new ChineseCharacterBasicDTO {
      Id = cchar.Id,
      Char = cchar.Char,
      Frequency = cchar.Frequency
    };
  }

  public static ChineseCharacterDTO ToDTO(this ChineseCharacter cchar)
  {
    return new ChineseCharacterDTO {
      Id = cchar.Id,
      Char = cchar.Char,
      TradChars = cchar.TradChars,
      Components = cchar.Components,
      Derivatives = cchar.Derivatives,
      Variants = cchar.Variants.Select(c => c.ToBasicDTO()).ToList(),
      Base = cchar.Base?.ToBasicDTO(),
      PrimaryPinyin = cchar.PrimaryPinyin,
      SecondaryPinyin = cchar.SecondaryPinyin,
      Definition = cchar.Definition,
      Description = cchar.Description,
      Frequency = cchar.Frequency
    };
  }
}