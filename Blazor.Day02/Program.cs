using Blazor.Day02.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Blazor.Day02
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<IService<Product>, ProductService>(); // note any request in agngular or blazor is a progressive request so if you didn't reload the page any scoped object (service) will be the same object untill you reload (refresh) the page even if you made any other request to the api to retrive any data (because it's a single page application not like MVC or API) in MVC or API any scoped object in them changes for each request 
            builder.Services.AddScoped<IService<Category>, CategoryService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
