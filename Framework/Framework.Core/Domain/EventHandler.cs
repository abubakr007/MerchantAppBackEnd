using System;

namespace Framework.Core.Domain
{
    public class EventHandler
    {
        private readonly Action<object> handlingAction;


        public EventHandler(Action<object> handlingAction)
        {
            this.handlingAction = handlingAction;
        }


        public Action<object> Action => handlingAction;
    }
}