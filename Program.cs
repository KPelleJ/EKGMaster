using EKGMaster.Interfaces;
using EKGMaster.Models;
using EKGMaster.Models.Handlers;
using EKGMaster.Models.ProductStuff;
using EKGMaster.Models.UserStuff;
using EKGMaster.Repositories;
using EKGMaster.Repositories.ProductRepositories;

namespace EKGMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<ICRUDRepository<Credential>, CredentialRepository>();
            builder.Services.AddSingleton<ICRUDRepository<Guide>, GuideRepository>();
            builder.Services.AddSingleton<ICRUDRepository<Message>, MessageRepository>();
            builder.Services.AddSingleton<ICRUDRepository<SalesAd>, SalesAdRepository>();
            builder.Services.AddSingleton<ICRUDRepository<User>, UserRepository>();
            builder.Services.AddSingleton<ICategoryRepository<Computer>, ComputerRepository>();
            builder.Services.AddSingleton<ICategoryRepository<Computer>, ComputerRepository>();
            builder.Services.AddSingleton<ICategoryRepository<Computer>, ComputerRepository>();
            builder.Services.AddSingleton<ICategoryRepository<Computer>, ComputerRepository>();
            builder.Services.AddSingleton<ICategoryRepository<Computer>, ComputerRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
