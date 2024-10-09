using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoDefinitvo___Northwind.Servicios.productos.productosService;

namespace ProyectoDefinitvo___Northwind.Servicios.categorias
{
    public interface IcategoriaService
    {
        void crearCategoria(crearCategoriaRequest request);
    }

    public class categoriaService : IcategoriaService
    {
        private readonly IValidator<crearCategoriaRequest> validator;

        public categoriaService(IValidator<crearCategoriaRequest> validator)
        {
            this.validator = validator;
        }
        public void crearCategoria(crearCategoriaRequest request)
        {

            validator.ValidateAndThrow(request);
        }
    }

    public class crearCategoriaRequest
    {
        public string CategoryName {  get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

    }

    public class crearCategoriaValidator : AbstractValidator<crearCategoriaRequest>
    {
        public crearCategoriaValidator()
        {
            RuleFor(a => a.CategoryName).NotEmpty().WithMessage("El nombre de la categoria es obligatorio.");

            RuleFor(a => a.Description).NotEmpty().WithMessage("La descripcion de la categoria es obligatoria.");

            RuleFor(a => a.Picture).NotEmpty().WithMessage("la imagen debe ser insertada");
        }
    }
}
