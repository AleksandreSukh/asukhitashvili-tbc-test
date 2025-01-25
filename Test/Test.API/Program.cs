
using Test.API.Filters;
using Test.API.Middleware;
using Test.Data;

namespace Test.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(opt => opt.Filters.Add(new RequestValidationFilter()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(c => new UnitOfWork(c.GetRequiredService<TestDbContext>()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            
            app.UseUnhandledExceptionLogging();
            app.UseRequestCulture();

            app.MapControllers();

            app.Run();
        }
    }
}
