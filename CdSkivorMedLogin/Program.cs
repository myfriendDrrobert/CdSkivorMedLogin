using CdSkivorMedLogin.Data;
using CdSkivorUppgift.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CdSkivorMedLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CdSkivorUppgiftContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CdSkivorUppgiftContext") ?? throw new InvalidOperationException("Connection string 'CdSkivorUppgiftContext' not found.")));

            // Add services to the container.
            builder.Services.AddHttpClient<UppgiftHttpClient>(client =>
            client.BaseAddress = new Uri("https://localhost:7180/"));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<CdSkivorUppgiftContext>();

            builder.Services.AddAuthentication().AddGoogle(option => { option.ClientId = "34570874501-q0uph6adla8dqds911sq9i7u96q94gch.apps.googleusercontent.com"; 
                option.ClientSecret = "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"; 
            });

            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IRecord, RecordRepo>();
            builder.Services.AddScoped<ISong, SongRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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