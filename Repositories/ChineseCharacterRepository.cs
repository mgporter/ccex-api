using ccex_api.Data;
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
      .Include(x => x.Components)
      .Include(x => x.Derivatives)
      .Include(x => x.Variants)
      .Include(x => x.Base)
      .FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<ChineseCharacter?> GetByCharAsync(string cchar)
  {

    // return await _context.ChineseCharacter
    //   .Include(x => x.Components)
    //   .Include(x => x.Derivatives)
    //   .Include(x => x.Variants)
    //   .Include(x => x.Base)
    //   .FirstOrDefaultAsync(x => x.Char == cchar);

    return await GetFullCharacterQuery().FirstOrDefaultAsync(x => x.Char == cchar);
  }

  private IIncludableQueryable<ChineseCharacter, ChineseCharacter?> GetFullCharacterQuery()
  {

    return _context.ChineseCharacter
      .Include(x => x.Variants)
      .Include(x => x.Base);
  }

}



// public Category GetById(int id)
//         {
//             var category = this.ObjectSet.FirstOrDefault(e => e.Id == id);

//             this.IncludeParentCategories(category);

//             return category;
//         }

//         private void IncludeParentCategories(Category category)
//         {
//             var currentCategory = category;

//             do
//             {
//                 this.UnitOfWork.Context.Entry(currentCategory).Reference(e => e.ParentCategory).Load();
//                 currentCategory = currentCategory.ParentCategory;
//             }
//             while (currentCategory != null);
//         }