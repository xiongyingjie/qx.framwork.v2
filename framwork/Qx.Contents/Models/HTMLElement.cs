﻿using System.Web.Mvc;

namespace Qx.Contents.Models
{
    public class HTMLElement
    {
        public MvcHtmlString Head;
        public MvcHtmlString Tail;

        public HTMLElement CreatElement(string key, string templete)
        {
            switch (key)
            {
                case "ul":
                    return new HTMLElement { Head = MvcHtmlString.Create(templete), Tail = MvcHtmlString.Create("</ul>") };
                case "li":
                    return new HTMLElement { Head = MvcHtmlString.Create(templete), Tail = MvcHtmlString.Create("</li>") };
                case "p":
                    return new HTMLElement { Head = MvcHtmlString.Create(templete), Tail = MvcHtmlString.Create("</p>") };
                case "span":
                    return new HTMLElement { Head = MvcHtmlString.Create(templete), Tail = MvcHtmlString.Create("</span>") };
                case "tr":
                    return new HTMLElement { Head = MvcHtmlString.Create(templete), Tail = MvcHtmlString.Create("</tr>") };
                case "td":
                    return new HTMLElement { Head = MvcHtmlString.Create(templete), Tail = MvcHtmlString.Create("</td>") };
                case "th":
                    return new HTMLElement { Head = MvcHtmlString.Create(templete), Tail = MvcHtmlString.Create("</th>") };
                default:
                    return new HTMLElement { Head = MvcHtmlString.Create("<unkonw>"), Tail = MvcHtmlString.Create("</unkonw>") };
            }
        }
    }
}
