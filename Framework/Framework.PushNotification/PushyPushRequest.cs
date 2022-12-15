namespace Framework.PushNotification
{
    public class PushyPushRequest
    {
        public object to;
        public object data;
        public object notification;

        public PushyPushRequest(object data, object to, object notification)
        {
            this.to = to;
            this.data = data;
            this.notification = notification;
        }
    }

}