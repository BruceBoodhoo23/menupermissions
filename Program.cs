// run using: dotnet run -- users.txt menus.txt > output1.json
// or navigate to bin and run: menupermissions.exe users.txt menus.txt > output1.json
using MenuPermissions._OriginalCode;
using MenuPermissions.Configuration;
using MenuPermissions.Menu;
using MenuPermissions.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace MenuPermissions
{
    class Program
    {
        // caching to avoid new initialization for every result
        private static readonly JsonSerializerOptions _jsonSerializerOptions = 
            new() { WriteIndented = true };

        // a test flag for local testing / debugging
        private static readonly bool _testMode = true;

        // a flag for using the old codebase - for R&D
        private static readonly bool _useOldCodeBase = false;

        static async Task Main(string[] args)
        {
            if (args.Length != 2 && !_testMode)
            {
                // use for normal test data files
                Console.WriteLine("Usage(test data): menupermissions.exe users.txt menus.txt > output1.json");
                // use for large test data files
                Console.WriteLine("Usage(big test data): menupermissions.exe usersbig.txt menusbig.txt > output2.json");
                return;
            }

            string userFilePath = _testMode ? "usersbig.txt" : args[0];
            string menuFilePath = _testMode ? "menusbig.txt" : args[1];

            // choose between old codebase and new codebase
            if(_useOldCodeBase)
            {
                await _OldProgram._OldMain(args);
                return;
            }

            // Dependency Injection Configuration / Setup
            var serviceProvider = DependencyInjectionConfig.ConfigureServices();

            var menuReader = serviceProvider.GetService<IMenuReader>();
            var userMapper = serviceProvider.GetService<IUserMapper>();

            try
            {
                var menus = await menuReader.ParseMenuAsync(menuFilePath);

                var userResults = userMapper.MapPermissionsToMenusAsync(userFilePath, menus);

                await foreach (var userResult in userResults)
                {
                    await JsonSerializer.SerializeAsync(Console.OpenStandardOutput(), userResult, _jsonSerializerOptions);
                }
            } 
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: File not found - {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: Invalid data format - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}