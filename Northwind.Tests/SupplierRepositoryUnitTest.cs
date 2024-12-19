using Microsoft.Data.SqlClient;
using Northwind.Infrastructure;

namespace Northwind.Tests
{
    public class SupplierRepositoryUnitTest
    {
        public class FakeConnectionFactory : IsqlConnectionFactory
        {
            public SqlConnection GetNewConnection()
            {
                return new SqlConnection("Data Source=LAPTOP-KK0P0EO7\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }


        [Fact]
        public void Prueba_GetSuppliers_devuelve_CualquierValor()
        {
            //Arrange
            var repository = new SupplierRepository(new FakeConnectionFactory());
            //Act
            var suppliers = repository.GetSuppliers();
            //ASSERT
            Assert.True(suppliers.Any());
        }
    }
}