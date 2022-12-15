using System;

namespace Framework.Core.DependencyInjection
{
    public interface IDiContainer
    {
        T Resolve<T>();

        object Resolve(Type type);
    }
}