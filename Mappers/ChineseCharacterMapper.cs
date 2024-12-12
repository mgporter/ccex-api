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

  public static ChineseCharacterComponentDTO ToComponentDTO(this ChineseCharacter cchar)
  {
    return new ChineseCharacterComponentDTO {
      Id = cchar.Id,
      Char = cchar.Char,
      Components = cchar.Components.Select(c => c.ToComponentDTO()).ToList(),
      MainPinyin = cchar.MainPinyin?.ToBasicDTO(),
      AllPinyins = cchar.AllPinyin.Select(p => p.ToBasicDTO()).ToList(),
      Frequency = cchar.Frequency
    };
  }

  public static ChineseCharacterDerivativeDTO ToDerivativeDTO(this ChineseCharacter cchar)
  {
    return new ChineseCharacterDerivativeDTO {
      Id = cchar.Id,
      Char = cchar.Char,
      Derivatives = cchar.Derivatives.Select(c => c.ToDerivativeDTO()).ToList(),
      MainPinyin = cchar.MainPinyin?.ToBasicDTO(),
      AllPinyins = cchar.AllPinyin.Select(p => p.ToBasicDTO()).ToList(),
      Frequency = cchar.Frequency
    };
  }

  public static ChineseCharacterDTO ToDTO(this ChineseCharacter cchar)
  {
    return new ChineseCharacterDTO {
      Id = cchar.Id,
      Char = cchar.Char,
      TradChars = cchar.TradChars.Select(c => c.ToDTO()).ToList(),
      Components = cchar.Components.Select(c => c.ToComponentDTO()).ToList(),
      Derivatives = cchar.Derivatives.Select(c => c.ToDerivativeDTO()).ToList(),
      Variants = cchar.Variants.Select(c => c.ToBasicDTO()).ToList(),
      BaseId = cchar.BaseId,
      Base = cchar.Base?.ToBasicDTO(),
      MainPinyin = cchar.MainPinyin?.ToBasicDTO(),
      AllPinyins = cchar.AllPinyin.Select(p => p.ToBasicDTO()).ToList(),
      Definition = cchar.Definition,
      Description = cchar.Description,
      Frequency = cchar.Frequency
    };
  }
}