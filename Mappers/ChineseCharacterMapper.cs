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
      Pinyins = cchar.Pinyins.Select(p => p.ToBasicDTO()).ToList(),
      Frequency = cchar.Frequency
    };
  }

  public static ChineseCharacterDTO ToDTO(this ChineseCharacter cchar)
  {
    return new ChineseCharacterDTO {
      Id = cchar.Id,
      Char = cchar.Char,
      Components = cchar.Components.Select(c => c.ToComponentDTO()).ToList(),
      Derivatives = cchar.Derivatives.Select(c => c.ToComponentDTO()).ToList(),
      Variants = cchar.Derivatives.Select(c => c.ToBasicDTO()).ToList(),
      BaseId = cchar.BaseId,
      Base = cchar.Base?.ToBasicDTO(),
      Pinyins = cchar.Pinyins.Select(p => p.ToBasicDTO()).ToList(),
      Definition = cchar.Definition,
      Description = cchar.Description,
      Frequency = cchar.Frequency
    };
  }
}