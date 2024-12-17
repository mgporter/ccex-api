using ccex_api.DTOs;
using ccex_api.Models;

namespace ccex_api.Repositories;

public interface IChineseCharacterRepository : IBaseRepository<ChineseCharacter, int>
{
  // public Task<ChineseCharacter?> GetByCharAsync(string cchar);
  public Task<ChineseCharacter?> GetFullCharDetails(string cchar);

  public Task<ISet<ChineseCharacterTreeMapDTO>> GetCharactersForTreeMap(ISet<string> chars);
}