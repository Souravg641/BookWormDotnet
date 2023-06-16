using BookWorm.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors((p) => p.AddDefaultPolicy(
    policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
            builder.Services.AddDbContext<Ccontext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("InventoryDatabase")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
            app.UseCors();
            app.Run();
        }
    }
}