
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SwaggerThemes;
using Tabu.DAL;
using Tabu.Enums;
using Tabu.Exceptions;
using Tabu.ExternalServices.Abstracts;
using Tabu.ExternalServices.Implements;
using Tabu.OperationFilters;
using Tabu.Services.Abstracts;
using Tabu.Services.Implements;

namespace Tabu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            builder.Services.AddCacheService(builder.Configuration, CacheTypes.Redis);

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddServices();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDbContext<TabuDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x=> x.OperationFilter<AddRequiredHeaderParameter>());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(Theme.UniversalDark);
            }

            app.UseTabuExceptionHandler();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
