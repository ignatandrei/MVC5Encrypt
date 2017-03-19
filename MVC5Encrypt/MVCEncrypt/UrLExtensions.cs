using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCEncrypt
{
    /// <summary>
    /// extension for having syntax like
    /// <a href='@Url.ActionEnc("mySecret", "TestEncrypt", new { a = 1, b = "asd" })'>Test</a>
    /// </summary>
    public static class UrLExtensions
    {
        /// <summary>
        /// default implementation 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="secret"></param>
        /// <param name="actionName"></param>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static string ActionEnc(this UrlHelper helper, string secret, string actionName, object routeValues)
        {
            var encDec = new EncryptDecrypt(secret);
            return ActionEnc(helper, encDec, actionName, routeValues);
        }
        /// <summary>
        /// generic implementation 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="encDec"></param>
        /// <param name="actionName"></param>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static string ActionEnc(this UrlHelper helper, IEncryptDecrypt encDec, string actionName, object routeValues)
        {

            var url = helper.Action(actionName, routeValues);
            var index = url.IndexOf("?");
            if (index == -1)
                return url;
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            Uri absoluteUri;
            if (uri.IsAbsoluteUri)
            {
                absoluteUri = uri;
            }
            else
            {
                absoluteUri = new Uri(new Uri("http://msprogrammer.serviciipeweb.ro/"), uri);
            }
            var q = absoluteUri.Query;
            var args = HttpUtility.ParseQueryString(q);
            if(args.Count == 0)
            {
                return url;
            }
            
            for (int i = 0; i < args.Count; i++)
            {
                var key = args.GetKey(i);
                args[key] = encDec.EncryptString(args[i]);
            }
            url = url.Substring(0, index+1);
            return url+args.ToString();
        }
    }
}
