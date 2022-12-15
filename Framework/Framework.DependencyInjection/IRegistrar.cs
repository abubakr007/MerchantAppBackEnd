using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection
{
    public interface IRegistrar
    {
        void Register(IServiceCollection services, string connectionString);
    }
}
