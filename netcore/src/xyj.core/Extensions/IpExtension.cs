using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using xyj.core.Utility;

namespace xyj.core.Extensions
{
    public static class IpExtension
    {
        public static IPLocation IpSearch(this IHostingEnvironment env, string ip)
        {
            return IpUtility.IpSearch(env,ip);
        }
        public static IPLocation IpSearch(this IHostingEnvironment env, HttpContext httpContext)
        {
            return IpUtility.IpSearch(env, httpContext);
        }
    }
}
