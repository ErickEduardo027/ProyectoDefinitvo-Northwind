using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using ProyectoDefinitvo___Northwind.Servicios.categorias;
using ProyectoDefinitvo___Northwind.Servicios.productos;
using ProyectoDefinitvo___Northwind.Servicios.suplidores;
using System.Reflection;
using System.Windows.Forms;
using Serilog;

namespace ProyectoDefinitvo___Northwind
{
    internal static class Program
    { 
        public static IConfiguration Configuration { get; private set; }
        [STAThread]
        static void Main()
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Logs/app.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); ;

            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                Configuration = builder.Build();

                var serviceCollection = new ServiceCollection();

                serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

                serviceCollection.AddTransient<LoginForm>();
                serviceCollection.AddTransient<mainMenu>();
                serviceCollection.AddScoped(p =>Log.Logger);
                serviceCollection.AddTransient<IproductosService, productosService>();
                serviceCollection.AddTransient<IcategoriaService, categoriaService>();
                serviceCollection.AddTransient<ISuplidorService, SuplidorService>();

                var serviceProvider = serviceCollection.BuildServiceProvider();

                ApplicationConfiguration.Initialize();

                var loginForm = serviceProvider.GetService<LoginForm>();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Algo esta pasando que esta mal, papi ;)");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
