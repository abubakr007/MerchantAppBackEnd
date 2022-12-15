using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Domain
{
    public class EventBus : IEventBus
    {
        private IList<EventSubscriptionItem> subcriptionList;


        public EventBus()
        {
            subcriptionList = new List<EventSubscriptionItem>();
        }


        public void Publish<TEvent>(TEvent domainEvent)
        {
            var existevent = subcriptionList.SingleOrDefault(a => a.EventType == typeof(TEvent));
            if (existevent != null)
                foreach (var handler in existevent.Handlers)
                    handler.Action(domainEvent);
        }


        public void Subscribe<TEvent>(Action<dynamic> action)
        {
            var existevent = subcriptionList.SingleOrDefault(a => a.EventType == typeof(TEvent));
            if (existevent == null)
            {
                var newsubs = new EventSubscriptionItem()
                {
                    EventType = typeof(TEvent), Handlers = new List<EventHandler> {new EventHandler(action)}
                };

                subcriptionList.Add(newsubs);
            }
            else
            {
                existevent.Handlers.Add(new EventHandler(action));
            }
        }
    }
}