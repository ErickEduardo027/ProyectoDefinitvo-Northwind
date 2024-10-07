using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using System.Reflection;
using System.Windows.Forms;

namespace ProyectoDefinitvo___Northwind
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            serviceCollection.AddTransient<LoginForm>();
            serviceCollection.AddTransient<mainMenu>();
            serviceCollection.AddTransient<IproductosService, productosService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            var loginForm = serviceProvider.GetService<LoginForm>();
            Application.Run(loginForm);
        }
    }
}
