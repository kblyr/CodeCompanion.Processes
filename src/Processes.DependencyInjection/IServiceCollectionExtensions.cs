using System.Reflection;
using CodeCompanion.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCompanion.Processes
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddProcessImplementations(this IServiceCollection services, Assembly containingAssembly, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var implementations = containingAssembly.GetTypes().Where(type => type.IsConcreteImplementationOf(typeof(IAsyncProcess<,>)));

            if (implementations.Any())
            {
                foreach (var implementation in implementations)
                {
                    services.Add(new ServiceDescriptor(implementation, implementation, lifetime));
                }
            }

            return services;
        }
    }
}