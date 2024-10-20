using FluentValidation;
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

    //public class pruebaProductoService : IproductosService
    //{
    //    public void CrearProducto(productosService.CrearOrdenRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

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
            public bool Discontinued { get; set; }
        }

        public class CrearProductoValidator : AbstractValidator<CrearProductoRequest>
        {
            public CrearProductoValidator()
            {
               
                RuleFor(p => p.ProductName).NotEmpty().WithMessage("El nombre del producto es obligatorio.");


                RuleFor(p => p.SupplierID)
                    .GreaterThanOrEqualTo(0).WithMessage("SupplierID debe ser un número mayor o igual a 0.");


                RuleFor(p => p.CategoryID)
                    .GreaterThanOrEqualTo(0).WithMessage("CategoryID debe ser un número mayor o igual a 0.");
                   
                
                RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("La cantidad por unidad es obligatoria.");

                RuleFor(p => p.UnitPrice)
                    .GreaterThanOrEqualTo(0).WithMessage("El precio unitario debe ser un número mayor o igual a 0.");


                RuleFor(p => p.UnitsInStock)
                    .GreaterThanOrEqualTo((short)0).WithMessage("Las unidades en stock deben ser un número mayor o igual a 0.");

                RuleFor(p => p.UnitsOnOrder)
                    .GreaterThanOrEqualTo((short)0).WithMessage("Las unidades pedidas deben ser un número mayor o igual a 0.");


                RuleFor(p => p.ReorderLevel)
                    .GreaterThanOrEqualTo((short)0).WithMessage("El nivel de reorden debe ser un número mayor o igual a 0.");
                    
                RuleFor(p => p.Discontinued).NotNull();
            }
        }
    }
}
