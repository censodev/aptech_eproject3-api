using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ViewModels
{
    public class RestResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public RestResponse()
        { }

        public RestResponse(bool status, string message, object data = null)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
