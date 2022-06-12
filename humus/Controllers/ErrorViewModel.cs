using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace humus.Controllers
{
    public class ErrorViewModel
    {
        public int id { get; set; }
        public object message;
        public object appSpecific;

        public ErrorViewModel(object message, object appSpecific)
        {
            this.message = message;
            this.appSpecific = appSpecific;
        }

        public object ErrorOccurred { get; set; }
    }
}