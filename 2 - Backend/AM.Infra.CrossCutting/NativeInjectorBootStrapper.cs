using AM.App.Services;
using AM.Domain.Interface.Repository;
using AM.Domain.Services;
using AM.Infra.Data.Context;
using AM.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ConsultaAppService>();
            services.AddScoped<ConsultaService>();
            services.AddScoped<AppDbContext>();
            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
        }
    }
}
