using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Framework.PushNotification
{
    public class PushyAPI
    {
        public static void SendPush(PushyPushRequest push, string secretApiKey)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.pushy.me/push?api_key=" + secretApiKey);
            SendPushNotification(push, request);
        }

        private static void SendPushNotification(PushyPushRequest push, HttpWebRequest request)
        {
            request.ContentType = "application/json";
            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(push);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (WebException exc)
            {
                string errorJSON = new StreamReader(exc.Response.GetResponseStream()).ReadToEnd();
                PushyAPIError error = JsonConvert.DeserializeObject<PushyAPIError>(errorJSON);
                //todo: log or what ?
                //throw new Exception(error.error);
                return;
            }
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseData = reader.ReadToEnd();
            reader.Close();
            response.Close();
            dataStream.Close();
        }
    }

}