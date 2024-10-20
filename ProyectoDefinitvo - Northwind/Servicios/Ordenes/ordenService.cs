using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitvo___Northwind.Servicios.Ordenes
{
    public interface IordenService
    {
        void CrearOrden(ordenService.CrearOrdenRequest request);
    }

    public class ordenService : IordenService
    {
        private readonly IValidator<CrearOrdenRequest> validator;

        public ordenService(IValidator<CrearOrdenRequest> validator)
        {
            this.validator = validator;
        }

        public void CrearOrden(CrearOrdenRequest request)
        {
            validator.ValidateAndThrow(request);
        }

        public class CrearOrdenRequest
        {
            public string CustomerID { get; set; }
            public int EmployeeID { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime RequiredDate { get; set; }
            public DateTime? ShippedDate { get; set; }
            public int ShipVia { get; set; }
            public decimal Freight { get; set; }
            public string ShipName { get; set; }
            public string ShipAddress { get; set; }
            public string ShipCity { get; set; }
            public string ShipRegion { get; set; }
            public string ShipPostalCode { get; set; }
            public string ShipCountry { get; set; }
        }

        public class CrearOrdenValidator : AbstractValidator<CrearOrdenRequest>
        {
            public CrearOrdenValidator()
            {
                RuleFor(o => o.CustomerID)
                    .NotEmpty().WithMessage("El ID del cliente es obligatorio.");

                RuleFor(o => o.EmployeeID)
                    .GreaterThanOrEqualTo(0).WithMessage("El ID del empleado debe ser un número mayor o igual a 0.");

                RuleFor(o => o.OrderDate)
                    .NotEmpty().WithMessage("La fecha de la orden es obligatoria.");

                RuleFor(o => o.RequiredDate)
                    .NotEmpty().WithMessage("La fecha requerida es obligatoria.");

                RuleFor(o => o.ShipVia)
                    .GreaterThanOrEqualTo(0).WithMessage("El método de envío debe ser un número mayor o igual a 0.");

                RuleFor(o => o.Freight)
                    .GreaterThanOrEqualTo(0).WithMessage("El costo de envío debe ser un número mayor o igual a 0.");

                RuleFor(o => o.ShipName)
                    .NotEmpty().WithMessage("El nombre del destinatario es obligatorio.");

                RuleFor(o => o.ShipAddress)
                    .NotEmpty().WithMessage("La dirección de envío es obligatoria.");

                RuleFor(o => o.ShipCity)
                    .NotEmpty().WithMessage("La ciudad de envío es obligatoria.");

                RuleFor(o => o.ShipCountry)
                    .NotEmpty().WithMessage("El país de envío es obligatorio.");
            }
        }
    }
}

