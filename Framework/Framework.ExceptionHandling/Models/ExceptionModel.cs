namespace Framework.ExceptionHandling.Models
{
    public class ExceptionModel
    {
        public ExceptionModel(int statusCode, int errorCode, string message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Message = message;
        }


        public int StatusCode { get; private set; }
        public int ErrorCode { get; private set; }
        public string Message { get; private set; }
    }
}