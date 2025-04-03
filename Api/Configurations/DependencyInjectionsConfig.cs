using Business.Interfaces;
using Business.Services;
using Data.Context;
using Data.Repository;
using Data.Repository.Interfaces;

namespace Api.Configurations
{
    public static class DependencyInjectionsConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<ContatoContextDb>();
            services.AddScoped<IContatoRepository, Repository>();

            services.AddScoped<IContatoService, ContatoService>();
            return services;
        }
    }
}
