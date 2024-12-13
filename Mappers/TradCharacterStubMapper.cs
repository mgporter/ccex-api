using ccex_api.DTOs;
using ccex_api.Aggregates;

namespace ccex_api.Mappers;

public static class TradCharacterStubMapper
{
  public static TradCharacterStubDTO ToDTO(this TradCharacterStub tchar)
  {
    return new TradCharacterStubDTO {
      Char = tchar.Char,
      Pinyin = tchar.Pinyin,
      Definition = tchar.Definition,
      Description = tchar.Description
    };
  }

}