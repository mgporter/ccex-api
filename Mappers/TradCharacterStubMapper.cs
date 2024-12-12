using ccex_api.DTOs;
using ccex_api.Models;

namespace ccex_api.Mappers;

public static class TradCharacterStubMapper
{
  public static TradCharacterStubDTO ToDTO(this TradCharacterStub tchar)
  {
    return new TradCharacterStubDTO {
      Id = tchar.Id,
      Char = tchar.Char,
      Pinyins = tchar.Pinyin.Select(p => p.ToBasicDTO()).ToList(),
      Definition = tchar.Definition,
      Description = tchar.Description
    };
  }

}