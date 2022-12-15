using System;

namespace Framework.Core.Domain
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent domainEvent);
        void Subscribe<TEvent>(Action<dynamic> action);
    }
}