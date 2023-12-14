using GildedRose.Factories;
using GildedRose.Services;

namespace GildedRose
{
    public static class AppDI
    {
        public static IServiceCollection AddServices(IServiceCollection services)
        {
            services
                .AddSingleton<IApp, App>()
                .AddScoped<IInventoryService, InventoryService>()
                .AddScoped<IItemFacadeFactory, ItemFacadeFactory>()
                .BuildServiceProvider();

            return services;
        }
    }
}
