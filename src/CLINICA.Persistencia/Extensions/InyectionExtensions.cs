﻿using CLINICA.Application.Interfaces;
using CLINICA.Persistencia.Context;
using CLINICA.Persistencia.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICA.Persistencia.Extensions
{
    public static class InyectionExtensions 
    {
        public static IServiceCollection addInyectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped<IAnalysisRepository, AnalysisRepository>();
            return services;
        }
    }
}
