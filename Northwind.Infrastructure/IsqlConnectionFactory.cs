using Microsoft.Data.SqlClient;

namespace Northwind.Infrastructure
{
    public interface IsqlConnectionFactory
    {
        SqlConnection GetNewConnection();
    }
}