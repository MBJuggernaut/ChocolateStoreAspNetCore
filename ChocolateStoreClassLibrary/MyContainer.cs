using ChocolateStoreClassLibrary.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChocolateStoreClassLibrary.Models
{
    public static class MyContainer
    {
        public static IServiceProvider provider;

        public static void Initialize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<StoreContext>();
            services.AddSingleton<IItemsDBRepository, ItemDBRepository>();
            services.AddSingleton<ISalesDBRepository, SalesDBRepository>();

            provider = services.BuildServiceProvider();
        }
    }
}
