using ccex_api.Data;
using ccex_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ccex_api.Repositories;

public class PinyinRepository : IPinyinRepository
{
  private readonly ApplicationDBContext _context;

  public PinyinRepository(ApplicationDBContext context)
  {
    _context = context;
  }

  public async void Create(Pinyin entity)
  {
    await _context.Pinyin.AddAsync(entity);
    await _context.SaveChangesAsync();
  }

  public async Task<List<Pinyin>> GetAllAsync()
  {
    return await _context.Pinyin.ToListAsync();
  }

  public async Task<Pinyin?> GetByIdAsync(int id)
  {
    return await _context.Pinyin.FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<Pinyin?> GetBySyllableAndToneMarkAsync(string syllable)
  {
    return await _context.Pinyin
      .Include(p => p.Chars)
      .FirstOrDefaultAsync(x => x.SyllableWithToneMark == syllable);
  }
}