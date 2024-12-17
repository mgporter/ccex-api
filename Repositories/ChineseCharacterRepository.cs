using ccex_api.Data;
using ccex_api.DTOs;
using ccex_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
    return await _context.ChineseCharacter
      .Include(x => x.Variants)
      .Include(x => x.Base)
      .FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<ISet<ChineseCharacterTreeMapDTO>> GetCharactersForTreeMap(ISet<string> chars)
  {
    ISet<ChineseCharacterTreeMapDTO> result = await _context.ChineseCharacter
      .Where(c => chars.Contains(c.Char))
      .Select(c => new ChineseCharacterTreeMapDTO(
        c.Id,
        c.Char,
        c.Components,
        c.Derivatives,
        c.PrimaryPinyin,
        c.Frequency
      ))
      .AsNoTracking()
      .ToHashSetAsync();

    return result;
  }

  public async Task<ChineseCharacter?> GetFullCharDetails(string cchar)
  {
    return await _context.ChineseCharacter
      .Include(x => x.Variants)
      .Include(x => x.Base)
      .AsNoTracking()
      .FirstOrDefaultAsync(x => x.Char == cchar);
  }

}