using ccex_api.Models;

namespace ccex_api.Repositories;

public interface IChineseCharacterRepository : IBaseRepository<ChineseCharacter, int>
{
  public Task<ChineseCharacter?> GetByCharAsync(string cchar);
}