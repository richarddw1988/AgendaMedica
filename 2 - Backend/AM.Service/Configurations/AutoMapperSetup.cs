using System;
using AutoMapper;
using DDDCore.App.AutoMapper;
using DDDCore.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DDDCore.Service.Configurations
{
  public static class AutoMapperSetup
  {
      public static void AddAutoMapperSetup(this IServiceCollection services)
      {
          if (services == null) throw new ArgumentNullException(nameof(services));

          services.AddAutoMapper(typeof(Startup));

          // Registering Mappings automatically only works if the 
          // Automapper Profile classes are in ASP.NET project
          AutoMapperConfig.RegisterMappings();
      }
  }
}