using System.Transactions;
using ccex_api.Data;
using Microsoft.EntityFrameworkCore;

namespace ccex_api.Init;

public class DBResourceLoader2
{

  private readonly DbContextOptions _dbContextOptions;

  public DBResourceLoader2(DbContextOptions options)
  {
    _dbContextOptions = options;
  }

  public void LoadInitialCharData()
  {
    using (TransactionScope scope = new TransactionScope())
    {
      var context = CreateContext();
      try {
        
        int count = 0;
        foreach (var cchar in new string[] {"我", "是", "到", "这", "测"})
        {
          context = AddToContext(context, cchar, ++count, 100);
        }
        context.SaveChanges();

      }
      finally {
        context.Dispose();
      }

      scope.Complete();
    }

  }

  private ApplicationDBContext AddToContext(ApplicationDBContext context, string cchar, int count, int commitCount)
  {
      context.ChineseCharacter.Add(
        new Models.ChineseCharacter {Char = cchar}
      );

      if (count % commitCount == 0)
      {
          context.SaveChanges();
          context = RecreateContext(context);
      }

      return context;

  }

  private ApplicationDBContext RecreateContext(ApplicationDBContext context)
  {
    context.Dispose();
    return CreateContext();
  }

  private ApplicationDBContext CreateContext()
  {
    var context = new ApplicationDBContext(_dbContextOptions);
    context.ChangeTracker.AutoDetectChangesEnabled = false;
    return context;
  }

}