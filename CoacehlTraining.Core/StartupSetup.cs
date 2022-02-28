using CoacehlTraining.Core.Interfaces;
using CoacehlTraining.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoacehlTraining.Core
{
    public static class StartupSetup
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPersonService), typeof(PersonService));
        }
    }
}
