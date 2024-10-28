namespace PRJ.Repository.UnitOfWorks;
public interface IUnitOfWork
{
    IRepository<SYS_User> UserRepo { get; }
    Task<int> Save();
}
