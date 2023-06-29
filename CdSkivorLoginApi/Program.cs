
using CdSkivorUppgift.Data;
using Microsoft.EntityFrameworkCore;

namespace CdSkivorLoginApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ISong, SongRepo>();
            builder.Services.AddScoped<IRecord, RecordRepo>();
            builder.Services.AddDbContext<CdSkivorUppgiftContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CdSkivorUppgiftContext") ?? throw new InvalidOperationException("Connection string 'CdSkivorUppgiftContext' not found.")));

            builder.Services.AddAuthentication().AddJwtBearer();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}