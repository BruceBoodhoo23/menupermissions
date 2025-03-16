using MenuPermissions.Commands;
using MenuPermissions.FileReader.Implementers;
using MenuPermissions.Menu;
using MenuPermissions.Users;
using Microsoft.Extensions.DependencyInjection;

namespace MenuPermissions.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register file reader strategies and user and menu mappers
            services.AddSingleton<ReadAllLinesFileReader>();
            services.AddSingleton<LineByLineFileReader>();

            services.AddTransient<IMenuReader>(provider =>
            {
                var fileReader = provider.GetService<ReadAllLinesFileReader>();
                return new MenuReader(fileReader);
            });

            services.AddTransient<IUserMapper>(provider =>
            {
                var fileReader = provider.GetService<LineByLineFileReader>();
                return new UserMapper(fileReader);
            });

            // Register commands
            services.AddTransient<ReadMenuCommand>();
            services.AddTransient<UserMapperCommand>();

            return services.BuildServiceProvider();
        }
    }
}
