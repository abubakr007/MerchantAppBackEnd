using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.PushNotification
{
    public interface INotificationFactory
    {
        INotificationSender CreateNotificationSender(ApplicationName applicationName);
    }
    public enum ApplicationName
    {
        SmartEpay,
        SmartEpayQueue
    }
}
