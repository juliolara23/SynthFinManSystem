using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SynthFinManSystem.Web.Objects
{
    public class DataResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public DataResponse(HttpStatusCode httpStatusCode, string message, object data)
        {
            Code = httpStatusCode == HttpStatusCode.OK ? 200 : 500;
            Message = message;
            Data = data;
        }
    }
}
