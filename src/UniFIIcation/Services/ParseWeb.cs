using System.Collections.Generic;
using HtmlAgilityPack;
using UniFIIcation.Services;
using System.Linq;

namespace UniFIIcation.Services
{
    public class ParseWeb : IMyParseWeb
    {
        public List<string> ExtractContent(string url)
        {
            List<string> content = new List<string>();
            string row = string.Empty;

            var Webget = new HtmlWeb();
            var doc = Webget.LoadFromWebAsync(url).Result;
            var URLS = doc.DocumentNode.Descendants("th")
                   .Select(e => e.InnerText);
            //.Where(s => !String.IsNullOrEmpty(s));
            for(int i = 0; i < URLS.Count(); ++i)
            {
                content.Add(URLS.ElementAt(i));
            }

            /*foreach (HtmlNode node in doc.DocumentNode.XPath)
            {
                row += node.ChildNodes[0].InnerHtml + "|";
            }
            content.Add(row);*/
            /*row = string.Empty;
            foreach (HtmlNode node in doc.DocumentNode.Ancestors("//td"))
            {
                row += node.ChildNodes[0].InnerHtml + "|";
            }
            content.Add(row);
            row = string.Empty;*/
            //content.Add("Text");

            return content;
        }
    }
}
