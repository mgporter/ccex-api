using ccex_api.Models;

namespace ccex_api.Repositories;

public interface ITradCharacterStubRepository : IBaseRepository<TradCharacterStub, int>
{
  public Task<TradCharacterStub?> GetByCharAsync(string cchar);
}