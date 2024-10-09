using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitvo___Northwind.Servicios.suplidores
{
    public interface ISuplidorService
    {
        void CrearSuplidor(CrearSuplidorRequest request);
    }

    public class SuplidorService : ISuplidorService
    {
        public void CrearSuplidor(CrearSuplidorRequest request)
        {
            var validator = new CrearSuplidorValidator();
            validator.ValidateAndThrow(request);
        }
    }

    public class CrearSuplidorRequest
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

    }

    public class CrearSuplidorValidator : AbstractValidator<CrearSuplidorRequest>
    {
        public CrearSuplidorValidator()
        {
            RuleFor(a => a.CompanyName).NotEmpty();
            RuleFor(a => a.ContactName).NotEmpty();
            RuleFor(a => a.ContactTitle).NotEmpty();
            RuleFor(a => a.Address).NotEmpty();
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.Region).NotEmpty();
            RuleFor(a => a.PostalCode).NotEmpty();
            RuleFor(a => a.Country).NotEmpty();
            RuleFor(a => a.Phone).NotEmpty();
        }
    }
}
