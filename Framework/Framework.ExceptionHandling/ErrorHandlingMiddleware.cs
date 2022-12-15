using System;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain.Exception;
using Framework.ExceptionHandling.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Framework.ExceptionHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;


        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            string Result;
            string message;
            httpContext.Response.ContentType = "text/plain";
            if (exception is ConfirmationException || exception.InnerException is ConfirmationException)
            {
                httpContext.Response.StatusCode = 520;
                message = exception.Message;
            }
            else
            {
                httpContext.Response.StatusCode = 500;
                message = exception.Message;
                while (exception.InnerException != null && !message.Contains(exception.InnerException.Message))
                {
                    exception = exception.InnerException;
                    message += "\n" + exception.Message;
                }
            }
            
            Result = JsonConvert.SerializeObject(new ExceptionModel(httpContext.Response.StatusCode, 500, message));

            return httpContext.Response.WriteAsync(Result,Encoding.UTF8);

        }
    }
}