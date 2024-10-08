using FluentValidation;
using System.Data;

namespace ProyectoDefinitvo___Northwind.FormulariosDeProyecto.Dialogos
{
    public static class ValidationExceptionExtension
    {
        public static string GetMessage(this ValidationException ex)
        {
            return string.Join("\n", ex.Errors.Select(a => a.ErrorMessage));
        }
    }
}
