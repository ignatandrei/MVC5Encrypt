using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCEncrypt
{
    /// <summary>
    /// MVC attribute to decrypt parameters- make sure that secret is the same as in
    /// <see cref="UrLExtensions.ActionEnc(UrlHelper, string, string, object)" /> or    
    /// </summary>
    public class MVCDecryptFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// the secret . Should be the same as in
        /// &lt;a href='@Url.Action("TestEncrypt", new { a = 1, b = "asd" })'&gt;Test&lt;/a&gt;
        /// </summary>
        public string secret;
        /// <summary>
        /// executes and decrypts
        /// </summary>
        /// <param name="filterContext"></param>
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
