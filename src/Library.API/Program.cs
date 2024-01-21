using Library.API.Application.Queries;
using Library.API.Mapper;
using Library.Domain.Model;
using Library.Infrastructure;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.API
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

            builder.Services.AddAutoMapper(typeof(DtoToBookMappingProfile));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            //builder.Services.AddEntityFrameworkSqlServer().AddDbContext<LibraryContext>(ServiceLifetime.Scoped);
            builder.Services.AddDbContext<LibraryContext>(cfg => cfg.UseSqlServer(builder.Configuration["ConnectionString"]));

            builder.Services.AddScoped(typeof(IBookRepository), typeof(BookRepository));

            //builder.Services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
            builder.Services.AddScoped<IBookQueries>(x => new BookQueries(builder.Configuration["ConnectionString"]!));


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