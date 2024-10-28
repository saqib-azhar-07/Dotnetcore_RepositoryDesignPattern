
namespace PRJ.Repository.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly MainContext _context;
    private DbSet<T> _dbSet;

    public Repository(MainContext _context)
    {
        this._context = _context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> Add(T entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        await _dbSet.AddAsync(entity);
        return entity;
    }
    public async Task<List<T>> Add(List<T> entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        await _dbSet.AddRangeAsync(entity);
        return entity;
    }

    public IQueryable<T> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<long> Count(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).LongCountAsync();
    }

    public async Task<T> Get(long id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<T> Get(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public void Remove(T entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        _dbSet.Remove(entity);
    }
    public void Remove(List<T> entities)
    {
        if (entities.Any())
            _dbSet.RemoveRange(entities);
        else
            throw new ArgumentNullException("entities");
    }

    public void Update(T entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        _dbSet.Update(entity);
    }
    public void Update(List<T> entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        _dbSet.UpdateRange(entity);
    }

}