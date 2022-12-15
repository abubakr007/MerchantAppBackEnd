using Framework.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection
{
    public class DiContainer : IDiContainer
    {
        private readonly IServiceProvider services;


        public DiContainer(IServiceProvider services)
        {
            this.services = services;
        }


        public T Resolve<T>()
        {
            return services.GetRequiredService<T>();
        }


        public object Resolve(Type type)
        {
            return services.GetRequiredService(type);
        }
    }
}
