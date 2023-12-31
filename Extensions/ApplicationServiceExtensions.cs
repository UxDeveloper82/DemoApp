using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
              
              services.AddDbContext<DataContext>(opt =>{
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
              });
              services.AddScoped<IUserRepository, UserRepository>();
              services.AddScoped<ITokenService, TokenService>();
              services.AddCors();
              services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

              return services;
        }
    }
}