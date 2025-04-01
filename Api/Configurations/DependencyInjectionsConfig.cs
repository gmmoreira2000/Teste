using Business.Interfaces;
using Business.Services;
using Data.Context;
using Microsoft.AspNetCore.WebSockets;

namespace Api.Configurations
{
    public static class DependencyInjectionsConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<ContatoContextDb>();
            services.AddScoped<IContatoRepository, IContatoRepository>();

            services.AddScoped<IContatoService, ContatoService>();
            return services;
        }
    }
}
