using Company.Ps1.BIL.Repositeries;
using Company.Ps1.BIL.Repositry;
using Company.Ps1.DAL.Data.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace Company.Ps1.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartment1 ,DepartmentRepo>(); //allow clr to create object
            builder.Services.AddDbContext<CompanyBDContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default"))); //allow clr to create object
            //builder.Services.AddDbContext<CompanyBDContext>(option => option.UseSqlServer(builder.Configuration["Default"])); //allow clr to create object
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
