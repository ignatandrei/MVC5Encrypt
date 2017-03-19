using System.Web;
using System.Web.Mvc;

namespace MVCEncrypt
{
    public class MVCDecryptActionFilter : IActionFilter
    {
        IEncryptDecrypt encDec;
        public MVCDecryptActionFilter(IEncryptDecrypt value)
        {
            encDec = value;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var args = HttpUtility.ParseQueryString(filterContext.HttpContext.Request.Url.Query);
            for (int i = 0; i < args.Count; i++)
            {
                var value = args[i];               
                filterContext.ActionParameters[args.GetKey(i)] = encDec.DecryptString(value);
            }


        }
    }
}
