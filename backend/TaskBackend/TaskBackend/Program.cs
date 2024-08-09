
using Microsoft.EntityFrameworkCore;
using TaskBackend.Repo;
using TaskBackend.TaskDBContext;

namespace TaskBackend
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

            builder.Services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DatabaseName")!);
            });

            builder.Services.AddTransient<ITaskRepo, TaskRepo>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AngularApp", policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:4200");
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AngularApp");

            app.MapControllers();

            app.Run();
        }
    }
}
