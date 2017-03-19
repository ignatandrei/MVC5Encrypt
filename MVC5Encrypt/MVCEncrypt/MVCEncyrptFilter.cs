using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCEncrypt
{
    public class MVCDecryptFilterAttribute : ActionFilterAttribute
    {
        public string secret;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var encDec=new EncryptDecrypt(secret);
            var args = HttpUtility.ParseQueryString(filterContext.HttpContext.Request.Url.Query);
            var parametersAction = filterContext.ActionDescriptor.GetParameters();
            for (int i = 0; i < args.Count; i++)
            {
                var value = args[i];               
                var name = args.GetKey(i);
                var type = parametersAction.First(it => it.ParameterName == name).ParameterType;
                filterContext.ActionParameters[name] = Convert.ChangeType(encDec.DecryptString(value), type);
                
            }


            base.OnActionExecuting(filterContext);
        }
    }
}
