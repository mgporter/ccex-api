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

  // public static ChineseCharacterComponentDTO ToComponentDTO(this ChineseCharacter cchar)
  // {
  //   return new ChineseCharacterComponentDTO {
  //     Id = cchar.Id,
  //     Char = cchar.Char,
  //     Components = cchar.Components.Select(c => c.ToComponentDTO()).ToList(),
  //     PrimaryPinyin = cchar.PrimaryPinyin,
  //     Frequency = cchar.Frequency
  //   };
  // }

  // public static ChineseCharacterDerivativeDTO ToDerivativeDTO(this ChineseCharacter cchar)
  // {
  //   return new ChineseCharacterDerivativeDTO {
  //     Id = cchar.Id,
  //     Char = cchar.Char,
  //     Derivatives = cchar.Derivatives.Select(c => c.ToDerivativeDTO()).ToList(),
  //     PrimaryPinyin = cchar.PrimaryPinyin,
  //     Frequency = cchar.Frequency
  //   };
  // }

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