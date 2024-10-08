using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using System.Reflection;
using System.Windows.Forms;

namespace ProyectoDefinitvo___Northwind
{
    internal static class Program
    { 
        public static IConfiguration Configuration { get; private set; }
        [STAThread]
        static void Main()
        {

            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); ;

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();


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
