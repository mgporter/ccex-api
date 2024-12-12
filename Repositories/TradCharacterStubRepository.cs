using ccex_api.Data;
using ccex_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ccex_api.Repositories;

public class TradCharacterStubRepository : ITradCharacterStubRepository
{

  private readonly ApplicationDBContext _context;

  public TradCharacterStubRepository(ApplicationDBContext context)
  {
    _context = context;
  }

  public async void Create(TradCharacterStub entity)
  {
    await _context.TradCharacterStub.AddAsync(entity);
    await _context.SaveChangesAsync();
  }

  public async Task<List<TradCharacterStub>> GetAllAsync()
  {
    return await _context.TradCharacterStub.ToListAsync();
  }

  public async Task<TradCharacterStub?> GetByIdAsync(int id)
  {
    return await _context.TradCharacterStub.FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<TradCharacterStub?> GetByCharAsync(string cchar)
  {
    return await _context.TradCharacterStub
      .Include(x => x.Pinyin)
      .FirstOrDefaultAsync(x => x.Char == cchar);
  }

}
