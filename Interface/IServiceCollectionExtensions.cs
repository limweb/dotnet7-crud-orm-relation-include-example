using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using crudapp.Core;
using crudapp.Interface;

namespace crudapp.Services
{
    /// <summary>
    /// Extension methods for IServiceCollection
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Automaatically register all repositories in an assembly.
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        /// <exception cref="InvalidOperationException">Repository must implement only one interface that implements IRepositoryBase</exception>
        public static void AddRepositories(this IServiceCollection services, Assembly assembly)
        {
            var repositoryTypes = assembly.GetTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface && type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IRepositoryBase<>)));

            // filter out RepositoryBase<>
            var nonBaseRepos = repositoryTypes.Where(t => t != typeof(RepositoryBase<>));

            foreach (var repositoryType in nonBaseRepos)
            {
                var interfaces = repositoryType.GetInterfaces()
                    .Where(@interface => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IRepositoryBase<>))
                    .ToList();

                if (interfaces.Count != 1)
                {
                    throw new InvalidOperationException($"Repository '{repositoryType.Name}' must implement only one interface that implements IRepositoryBase<T>.");
                }

                services.AddScoped(interfaces[0], repositoryType);
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}