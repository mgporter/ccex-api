using ccex_api.Data;
using ccex_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ccex_api.Repositories;

public class ChineseCharacterRepository : IChineseCharacterRepository
{

  private readonly ApplicationDBContext _context;

  public ChineseCharacterRepository(ApplicationDBContext context)
  {
    _context = context;
  }

  public async void Create(ChineseCharacter entity)
  {
    await _context.ChineseCharacter.AddAsync(entity);
    await _context.SaveChangesAsync();
  }

  public async Task<List<ChineseCharacter>> GetAllAsync()
  {
    return await _context.ChineseCharacter.ToListAsync();
  }

  public async Task<ChineseCharacter?> GetByIdAsync(int id)
  {
    return await _context.ChineseCharacter.FirstOrDefaultAsync(x => x.Id == id);
  }

}
