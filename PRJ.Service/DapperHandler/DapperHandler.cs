namespace PRJ.Service.QueryHandlers;

public static class DapperHandler
{
    public static async Task<bool> Execuete(string query)
    {
        using (var connection = new SqlConnection(ConfigurationStrings.DBConntectionString))
        {
            var result = await connection.ExecuteAsync(query);
            return true;
        }
    }

    public static async Task<T> Query<T,U>(string query , U obj)
	{
        using (var connection = new SqlConnection(ConfigurationStrings.DBConntectionString))
        {
            var result = await connection.QueryAsync<T>(query, obj);
            return result.FirstOrDefault();
        }

    }

    public static async Task<List<T>> QueryList<T, U>(string query , U obj)
    {
        using (var connection = new SqlConnection(ConfigurationStrings.DBConntectionString))
        {
            var result = await connection.QueryAsync<T>(query, obj);
            return result.ToList();
        }
    }

}
