using Microsoft.Data.SqlClient;

namespace RTMS.Plugins.SqlServer;

public class SqlConnectionFactory(string rtmsConnectionString)
{
    public SqlConnection CreateConnection()
    {
        return new SqlConnection(rtmsConnectionString);
    }

}
