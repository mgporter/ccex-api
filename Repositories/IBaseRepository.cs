namespace ccex_api.Repositories;

public interface IBaseRepository<T, KEY>
{
  Task<List<T>> GetAllAsync();

  Task<T?> GetByIdAsync(KEY id);

  void Create(T entity);

  // void Update(KEY key, T entity);

  // void Delete(KEY key);

}