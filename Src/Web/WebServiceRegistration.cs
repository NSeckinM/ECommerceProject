using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Services;

namespace Web
{
    public static class WebServiceRegistration
    {

        public static void AddWebServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IHomeViewModelService, HomeViewModelService>();
        }

    }
}
