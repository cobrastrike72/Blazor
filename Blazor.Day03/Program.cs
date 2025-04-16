using Blazor.Day03.Models.DepartmentModels;
using Blazor.Day03.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Blazor.Day03
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var providerIP = builder.Configuration["ProviderIP"]; // from appsetting it has to be in wwwroot in blazor
            if (string.IsNullOrEmpty(providerIP))
            {
                throw new InvalidOperationException("ProviderIP is not configured in appsettings.json");
            }
            // if you have more than more than one api service
            builder.Services.AddHttpClient<IService<StudentViewModel>, StudentService>(
                client =>
                {
                    client.BaseAddress = new Uri(providerIP);
                }
            );

            // if you have more than more than one api service
            builder.Services.AddHttpClient<IService<DepartmentViewModel>, DepartmentService>(
                client =>
                {
                    client.BaseAddress = new Uri(providerIP);
                }
            );


            // this if you have one sigle api service 
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("ProviderURI").Value) });

            await builder.Build().RunAsync();
        }
    }
}
