using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UniversityManagementSystem.API.StartupExtension
{
    public static class DatabaseExtensionsHelper
    {
        public static IServiceCollection AddDatabaseExtensionHelper(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
