
using Lab2.WebAPI.MappingProfiles;
using Lab2.WebAPI.Models;
using Lab2.WebAPI;
using Microsoft.EntityFrameworkCore;

namespace Lab2.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string holder = "";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddXmlSerializerFormatters();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddDbContext<ITIContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped
            );

            builder.Services.AddCors( // you have to add cors only in case of making ajax call in the browser if you made it from a desktop app you won't need to configure it here  and not cors are not configured or allowed by default
                options =>
                {
                    options.AddPolicy(holder, builder =>
                    {
                        builder.AllowAnyOrigin(); // any domain that uses ajax call (any jquery , angular, react ) project they all use ajax call
                        builder.AllowAnyMethod(); // like post , get 
                        builder.AllowAnyHeader();
                    });
                }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(option => option.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseCors(holder);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
