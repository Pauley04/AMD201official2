using AMD201official2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using AspNetCoreRateLimit;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using AMD201official2.Models;
namespace AMD201official2
{
    public class Program
    {

        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);

			//Add services to container
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(connectionString));
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddControllers();

			//Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Url}/{action=ExpandIndex}/{id?}");

            app.Run();
        }
    }
}
