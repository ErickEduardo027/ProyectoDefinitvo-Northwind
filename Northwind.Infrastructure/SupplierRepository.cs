using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Northwind.Application.Abstractions;
using Northwind.Models;

namespace Northwind.Infrastructure
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IsqlConnectionFactory connectionFactory;

        public SupplierRepository(IsqlConnectionFactory connectionFactory) 
        {
            this.connectionFactory = connectionFactory;
        }
        
        public IEnumerable<Supplier> GetSuppliers()
        {
            var connection = connectionFactory.GetNewConnection();
            return connection.Query<Supplier>("SELECT * FROM Suppliers");
        }
    }

    public class sqlConnectionFactory : IsqlConnectionFactory
    {
        private readonly IConfiguration configuration;

        public sqlConnectionFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public SqlConnection GetNewConnection()
        {
            return new SqlConnection(configuration.GetConnectionString("NorthwindConnectionString"));
        }

    }
}
