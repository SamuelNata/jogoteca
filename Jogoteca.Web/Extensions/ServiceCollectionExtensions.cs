using System.Reflection;
using Jogoteca.Repository;
using Jogoteca.Service;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace Jogoteca.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Este metodo irá configuar a injeção de dependencia de todas as Repositories e Services
        /// contanto que exista apenas uma implementação para cada uma
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
        {
            services
                .RegisterAssemblyPublicNonGenericClasses(
                    Assembly.GetAssembly(typeof(IGenericRepository<>)),
                    Assembly.GetAssembly(typeof(IGenericService<>))
                )
                .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            return services;
        }
    }
}