using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Abstractions
{
    public interface ISupplierRepository
    {
        public IEnumerable<Supplier> GetSuppliers();
    }
}
