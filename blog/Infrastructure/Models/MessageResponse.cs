using System;
using System.ComponentModel;
using System.Net;

namespace blog.Models
{
    public class MessageResponse
    {
        [DefaultValue(200)]
        public HttpStatusCode Status { get; set; }

        public string Message { get; set; }

        public MessageResponse(HttpStatusCode status, string message)
        {
            Status = status;
            Message = message;
        }
        public static MessageResponse mapError(HttpStatusCode status, string message)
        {
           return new MessageResponse(status, message);

        }
    }
}
