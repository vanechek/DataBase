using DataBase.Service.Repository;
using DataBase.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase.Service
{
    public static class DiContainer
    {
        private static ServiceProvider serviceProvider;
        public static void Unit()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<AuthenticationViewModel>();
            serviceCollection.AddTransient<SettingsDataBaseViewModel>();
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddTransient<DataBaseViewModel>();

            serviceCollection.AddSingleton<PageService>();
            serviceCollection.AddSingleton<SqlService>();
            serviceCollection.AddSingleton<DataBaseService>();
            serviceCollection.AddSingleton<IDataBaseControlerService, Gu12ControlerRepository>();
            serviceProvider = serviceCollection.BuildServiceProvider();

            foreach (var service in serviceCollection)
            {
                serviceProvider.GetRequiredService(service.ServiceType);
            }
        }
        public static T GetViewModel<T>() => serviceProvider.GetRequiredService<T>();
    }
}
