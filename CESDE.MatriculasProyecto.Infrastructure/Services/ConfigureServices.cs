using CESDE.MatriculasProyecto.Application.Interfaces;
using CESDE.MatriculasProyecto.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CESDE.MatriculasProyecto.Infrastructure.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AgoraContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Agora"));
            });

            services.AddDbContext<DBCESDEV3Context>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBCESDEV3"));
            });

            services.AddScoped<IAgoraDbContext, AgoraContext>();

            services.AddScoped<IApplicationDbContext, DBCESDEV3Context>();

            return services;
        }

    }
}
