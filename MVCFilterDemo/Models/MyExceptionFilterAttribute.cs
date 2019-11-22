using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilterDemo.Models
{
    public class MyExceptionFilterAttribute: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);//表示基类的异常处理方法，依然保留，在下面写出自己的异常处理，自己如何处理呢？
        }
    }
}