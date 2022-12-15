using Framework.Core.PushNotification;
using Microsoft.Extensions.Configuration;

namespace Framework.PushNotification
{
    public class SmartEpayQueueNotificationSender : NotificationSenderBase, INotificationSender
    {
        private string _SecretKey;
        public SmartEpayQueueNotificationSender(IConfiguration configuration)
        {
            _SecretKey = configuration.GetSection("PushNotification").GetSection("ApiSecretQueue").Value;
        }
        public override string AppSecretKey => _SecretKey;

    }


}