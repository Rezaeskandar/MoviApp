using Microsoft.EntityFrameworkCore;
using MoviApp.Data;

namespace MoviApp
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
            // oppetion tow added for connectiostring 
            builder.Services.AddDbContext<ApiDbContext>(dbContextopption => dbContextopption.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= MovieDb;"));
          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseAuthorization();
            //added
           
            app.UseEndpoints(Endpoint =>
            {
                Endpoint.MapControllers();

            });

            app.Run();
        }
    }
}