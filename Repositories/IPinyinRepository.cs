using ccex_api.Models;

namespace ccex_api.Repositories;

public interface IPinyinRepository : IBaseRepository<Pinyin, int>
{
  public Task<Pinyin?> GetBySyllableAndToneMarkAsync(string syllable);
}