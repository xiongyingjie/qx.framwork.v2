using System.IO;
using JinianNet.JNTemplate;

namespace xyj.core.Utility
{
   
    public static class TemplateUtility
    {
        public static string Render<T>(T model,string path)
        {
            var conf = JinianNet.JNTemplate.Configuration.EngineConfig.CreateDefault();//创建默认的配置对象，建议使用此方法而不是直接 new Configuration.EngineConfig();
            conf.StripWhiteSpace = false;//是否处理标签前后空白字符，启用后生成的代码更加紧凑，默认为true
            Engine.Configure(conf);//应用配置
            //ITemplate template = Engine.CreateTemplate("hello,$name!");
            ITemplate template = Engine.LoadTemplate(path);
            template.Context.TempData["model"] = model;
            //template.Context.CurrentPath = @"c:\";//当前模板路径
            TextWriter t = new StringWriter();
            template.Render(t);
            return t.ToString();
        }
    }

}
