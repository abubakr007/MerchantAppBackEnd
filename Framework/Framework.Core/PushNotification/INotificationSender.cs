namespace Framework.Core.PushNotification
{
    public interface INotificationSender
    {
        string AppSecretKey { get; }
        void SendToSubject(string topic, string title, string message, object data);
        void SendWithToken(string token, string title, string message, object data);
    }
}
