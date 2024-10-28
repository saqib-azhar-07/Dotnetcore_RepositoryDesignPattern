namespace PRJ.Repository.UnitOfWorks;
public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly MainContext _context;
    public UnitOfWork(MainContext _context)
    {
        this._context = _context;
    }

    private IRepository<SYS_User> _userRepo;
    public IRepository<SYS_User> UserRepo
    {
        get
        {
            if (_userRepo == null)
                _userRepo = new Repository<SYS_User>(_context);
            return _userRepo;
        }
    }

    public async Task<int> Save()
    {
        var res = await _context.SaveChangesAsync();
        return res;
    }

    public void Dispose()
    {
        this._context.Dispose();
    }
}
