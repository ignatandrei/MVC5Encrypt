using System.Web;
using System.Web.Mvc;

namespace MVCEncrypt
{
    /// <summary>
    /// MVC attribute to decrypt parameters- make sure that secret is the same as in
    /// <see cref="UrLExtensions.ActionEnc(UrlHelper, string, string, object)" /> or    
    /// </summary>
    public class MVCDecryptActionFilter : IActionFilter
    {
        IEncryptDecrypt encDec;
        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="value"></param>
        public MVCDecryptActionFilter(IEncryptDecrypt value)
        {
            encDec = value;
        }
        /// <summary>
        /// just override
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            return;
        }
        /// <summary>
        /// executes and decrypts
        /// </summary>
        /// <param name="filterContext"></param>
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
