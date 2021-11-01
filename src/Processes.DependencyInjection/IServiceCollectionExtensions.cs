using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCompanion.Processes
{
    public static class IServiceCollectionExtensions
    {
        private static IEnumerable<Type> GetSpecificImplemenetationTypes(Assembly containingAssembly, params Type[] genericInterfaceTypes) => containingAssembly.GetTypes()
            .Where(type =>
                !type.IsGenericTypeDefinition &&
                !type.ContainsGenericParameters &&
                type.GetInterfaces().Any(interfaceType => genericInterfaceTypes.Contains(interfaceType.GetGenericTypeDefinition()))
            );

        private static IServiceCollection AddImplementation(this IServiceCollection services, Type implementation, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.Add(new ServiceDescriptor(implementation, implementation, lifetime));
            return services;
        }

        public static IServiceCollection AddProcesses(this IServiceCollection services, Assembly containingAssembly, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            foreach (var processType in GetSpecificImplemenetationTypes(containingAssembly, typeof(IProcess<,>), typeof(IAsyncProcess<,>)))
            {
                services.AddImplementation(processType, lifetime);
            }

            return services;
        }
    }
}