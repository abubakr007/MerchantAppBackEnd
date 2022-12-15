using Framework.Core.PushNotification;
using Microsoft.Extensions.Configuration;

namespace Framework.PushNotification
{
    public class SmartEpayNotificationSender : NotificationSenderBase, INotificationSender
    {
        private string _SecretKey;
        public SmartEpayNotificationSender(IConfiguration configuration)
        {
            _SecretKey = configuration.GetSection("PushNotification").GetSection("ApiSecretSmartEpay").Value;
        }

        public override string AppSecretKey => _SecretKey;
    }


}