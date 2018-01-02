using System;
using System.Collections.Generic;
using System.Linq;

namespace Qx.Tools.CommonExtendMethods
{
    public static class TemplateExtension
    {
        public static string Render<T>(this T model, string path)
        {
           return TemplateUtility.Render(model, path);
        }
    }
}