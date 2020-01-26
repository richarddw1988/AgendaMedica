using AM.App.Services;
using AM.Domain.Interface;
using AM.Domain.Interfaces;
using AM.Infra.CrossCutting.Models;
using AM.Infra.Data.Context;
using AM.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<UserAppService>();
            services.AddScoped<AppDbContext>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
