using ChocolateStoreClassLibrary.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChocolateStoreClassLibrary.Models
{
    public class MyContainer
    {
        private static IServiceProvider _provider;
        public static IServiceProvider Provider
        {
            get
            {
                if (_provider == null)
                {
                    Initialize();
                }

                return _provider;
            }
        }

        public static void Initialize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<StoreContext>();
            services.AddSingleton<IItemsDBRepository, ItemDBRepository>();
            services.AddSingleton<ISalesDBRepository, SalesDBRepository>();

            _provider = services.BuildServiceProvider();
        }
    }
}
