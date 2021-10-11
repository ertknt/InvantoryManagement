using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvantoryManagement.Models
{
    public class ResultModel
    {
        public bool Status { get; set; }

        public int Parameter { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }
    }
    public class ResultModel<T>
    {
        public bool Status { get; set; }

        public int Parameter { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public T Data { get; set; }

        public string ParameterString { get; set; }
    }
}