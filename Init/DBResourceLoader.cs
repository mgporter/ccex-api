using System.Transactions;
using ccex_api.Data;
using ccex_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ccex_api.Init;

public static class DBResourceLoader
{

  public static void LoadInitialCharData(
    DbContext context
  )
  {
    // using (TransactionScope scope = new TransactionScope())
    // {
      // var context = CreateContext();
      try {
        
        int count = 0;
        foreach (var cchar in new string[] {"我", "是", "到"})
        {
          context = AddToContext(context, cchar, ++count, 100);
        }
        context.SaveChanges();

      }
      finally {
        // context.Dispose();
      }

    //   scope.Complete();
    // }

  }

  private static DbContext AddToContext(DbContext context, string cchar, int count, int commitCount)
  {
      context.Set<ChineseCharacter>().Add(
        new Models.ChineseCharacter {Char = cchar}
      );

      if (count % commitCount == 0)
      {
          context.SaveChanges();
          // context = RecreateContext(context);
      }

      return context;

  }

  private static ApplicationDBContext RecreateContext(ApplicationDBContext context)
  {
    context.Dispose();
    return CreateContext();
  }

  private static ApplicationDBContext CreateContext()
  {
    var context = new ApplicationDBContext(null);
    context.ChangeTracker.AutoDetectChangesEnabled = false;
    return context;
  }

}