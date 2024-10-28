

namespace PRJ.DataAccess.DapperContexts;
public class DapperContext
{
    private readonly string _connectionString;
    public DapperContext()
    {
        _connectionString = ConfigurationStrings.DBConntectionString;
    }
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}
