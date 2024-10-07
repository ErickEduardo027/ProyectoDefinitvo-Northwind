﻿using FluentValidation;
using ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitvo___Northwind.Servicios.productos
{
    public interface IproductosService
    {
        void CrearProducto(productosService.CrearProductoRequest request);
    }

    public class pruebaProductoService : IproductosService
    {
        public void CrearProducto(productosService.CrearProductoRequest request)
        {
            throw new NotImplementedException();
        }
    }

    public class productosService : IproductosService
    {
        private readonly IValidator<CrearProductoRequest> validator;

        public productosService(IValidator<CrearProductoRequest> validator) 
        {
            this.validator = validator;
        }

        public void CrearProducto(CrearProductoRequest request)
        {
            validator.ValidateAndThrow(request);
        }

        public class CrearProductoRequest
        {
            public string ProductName { get; set; }
            public int SupplierID { get; set; }
            public int CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public short UnitsInStock { get; set; }
            public short UnitsOnOrder { get; set; }
            public short ReorderLevel { get; set; }
            public string Discontinued { get; set; }
        }

        public class CrearProductoValidator : AbstractValidator<CrearProductoRequest>
        {
            public CrearProductoValidator()
            {
                RuleFor(p => p.ProductName).NotEmpty();

                RuleFor(p => p.SupplierID).GreaterThan(0);

                RuleFor(p => p.CategoryID).GreaterThan(0);

                RuleFor(p => p.QuantityPerUnit).NotEmpty();

                RuleFor(p => p.UnitPrice).GreaterThan(0);

                RuleFor(p => p.UnitsInStock).GreaterThan((short)0);

                RuleFor(p => p.UnitsOnOrder).GreaterThan((short)0);

                RuleFor(p => p.ReorderLevel).GreaterThan((short)0);

                RuleFor(p => p.Discontinued).NotEmpty();
            }
        }
    }
}