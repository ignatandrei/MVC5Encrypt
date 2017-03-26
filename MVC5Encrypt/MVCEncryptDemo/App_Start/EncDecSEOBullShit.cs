using MVCEncrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEncryptDemo
{
    public class EncDecSEOBullShit : IEncryptDecrypt
    {
        //public static string FullName = typeof(EncDecSEOBullShit).AssemblyQualifiedName;
        const string seo = "this-is-seo-";
        public string DecryptString(string value)
        {
            return value.Replace(seo, "");
        }

        public string EncryptString(string value)
        {
            return seo + value;
        }
    }
}