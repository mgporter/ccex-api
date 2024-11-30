using ccex_api.DTOs;
using ccex_api.Models;

namespace ccex_api.Mappers;

public static class PinyinMapper
{
  public static PinyinDTO ToDTO(this Pinyin pinyin)
  {
    return new PinyinDTO {
      Id = pinyin.Id,
      Syllable = pinyin.Syllable,
      ToneNumber = pinyin.ToneNumber,
      SyllableWithToneMark = pinyin.SyllableWithToneMark,
      Chars = pinyin.Chars.Select(c => c.ToBasicDTO()).ToList()
    };
  }

  public static PinyinBasicDTO ToBasicDTO(this Pinyin pinyin)
  {
    return new PinyinBasicDTO {
      Id = pinyin.Id,
      Syllable = pinyin.Syllable,
      ToneNumber = pinyin.ToneNumber,
      SyllableWithToneMark = pinyin.SyllableWithToneMark,
    };
  }
}