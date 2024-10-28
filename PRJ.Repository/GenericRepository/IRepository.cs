namespace PRJ.Repository.Repositories;
public interface IRepository<T> where T :class
{
    Task<T> Add(T entity);
    Task<List<T>> Add(List<T> entity);
    
    IQueryable<T> AsQueryable();

    Task<long> Count(Expression<Func<T, bool>> predicate);

    Task<T> Get(long id);
    Task<T> Get(Expression<Func<T, bool>> predicate);

    Task<List<T>> GetAll();
    Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
    
    void Remove(T entity);
    void Remove(List<T> entities);

    void Update(T entity);
    void Update(List<T> entity);
}
