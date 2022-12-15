using Framework.Core.PushNotification;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.PushNotification
{
    public class NotificationFactory : INotificationFactory
    {
        private readonly IConfiguration configuration;

        public NotificationFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public INotificationSender CreateNotificationSender(ApplicationName applicationName)
        {
            switch (applicationName)
            {
                case ApplicationName.SmartEpay:
                    return new SmartEpayNotificationSender(configuration);
                case ApplicationName.SmartEpayQueue:
                    return new SmartEpayQueueNotificationSender(configuration);
                default:
                    throw new ArgumentException();
            }    
        }
    }
}
