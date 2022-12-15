using Framework.Core.PushNotification;
using System.Collections.Generic;

namespace Framework.PushNotification
{

    public abstract class NotificationSenderBase : INotificationSender
    {
        public abstract string AppSecretKey { get; }
        public void SendToSubject(string topic, string title, string message, object data)
        {
            var to = "/topics/" + topic;
            var notification = new Dictionary<string, object>
            {
                {"badge", 1}, {"sound", "ping.aiff"}, { "title", title}, {"body", message + "\u270c"}
            };
            var push = new PushyPushRequest(data, to, notification);
            PushyAPI.SendPush(push, AppSecretKey);
        }

        public void SendWithToken(string deviceToken, string title, string message, object data)
        {
            List<string> deviceTokens = new List<string> { deviceToken };
            string[] to = deviceTokens.ToArray();
            var notification = new Dictionary<string, object>
            {
                { "badge", 1 },
                { "sound", "ping.aiff" },
                { "title", title },
                { "body", message + " \u270c" }
            };
            PushyPushRequest push = new PushyPushRequest(data, to, notification);
            PushyAPI.SendPush(push, AppSecretKey);
        }
    }


}