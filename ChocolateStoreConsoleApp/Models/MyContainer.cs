using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChocolateStoreConsoleApp.Models
{
    public static class MyContainer
    {
        public static IServiceProvider provider;

        public static IServiceProvider Initialize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<SalesContext>();

            provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
