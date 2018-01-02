using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace xyj.core
{
    public class CsprojUtility
    {
        //在.csproj文件中导入新文件  
        public static void GenCsproj(string COMMONROTOCOLTEST_DIR,string CsprojFile)
        {
            //ProtocolModel目前的cs文件列表  
            var files = Directory.GetFiles(COMMONROTOCOLTEST_DIR, "*.cs");
            List<String> currFiles = new List<String>();

            foreach (var file in files)
            {
                String path = file.ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"ProtocolModel").Append(path.Substring(path.LastIndexOf(@"\")));
                currFiles.Add(sb.ToString());
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(CsprojFile);
            //Project节点  
            XmlNodeList xnl = doc.ChildNodes[0].ChildNodes;
            if (doc.ChildNodes[0].Name.ToLower() != "project")
            {
                xnl = doc.ChildNodes[1].ChildNodes;
            }
            foreach (XmlNode xn in xnl)
            {
                //找到包含compile的节点  
                if (xn.ChildNodes.Count > 0 && xn.ChildNodes[0].Name.ToLower() == "compile")
                {
                    foreach (XmlNode cxn in xn.ChildNodes)
                    {
                        if (cxn.Name.ToLower() == "compile")
                        {
                            XmlElement xe = (XmlElement)cxn;
                            String includeFile = xe.GetAttribute("Include");
                            //项目中已包含的ProtocolModel  
                            if (includeFile.StartsWith(@"ProtocolModel\"))
                            {
                                Console.WriteLine(includeFile);
                                foreach (String item in currFiles)
                                {
                                    //将已经包含在项目中的cs文件在所有文件的列表中剔除  
                                    //操作完之后currFiles中剩下的就是接下来需要包含到项目中的文件  
                                    if (item.Equals(includeFile))
                                    {
                                        currFiles.Remove(item);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    //将剩下的文件加入csproj中  
                    foreach (String item in currFiles)
                    {
                        XmlElement xelKey = doc.CreateElement("Compile", doc.DocumentElement.NamespaceURI);
                        XmlAttribute xelType = doc.CreateAttribute("Include");
                        xelType.InnerText = item;
                        xelKey.SetAttributeNode(xelType);
                        xn.AppendChild(xelKey);
                    }
                }
            }
            doc.Save(CsprojFile);
        }
    }
}
