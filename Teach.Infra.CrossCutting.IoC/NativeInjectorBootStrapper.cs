using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Teach.Domain.Interfaces;
using Teach.Infra.Data.Context;
using Teach.Infra.Data.UoW;

namespace Teach.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TeachContext>();
        }
    }
}
