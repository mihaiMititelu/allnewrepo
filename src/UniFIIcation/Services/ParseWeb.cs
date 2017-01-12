using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace UniFIIcation.Services
{
    public class ParseWeb : IMyParseWeb
    {
        public List<string> ExtractContent(string url)
        {
            List<string> content = new List<string>();
            string row = string.Empty;

            var Webget = new HtmlWeb();
            try
            {
                var doc = Webget.LoadFromWebAsync(url).Result;
                var headers = doc.DocumentNode.Descendants("th")
                       .Select(e => e.InnerText);
                //.Where(s => !String.IsNullOrEmpty(s));
                content = headers.ToList<string>();

                var data = doc.DocumentNode.Descendants("td")
                       .Select(e => e.InnerText);

                foreach (var item in data)
                {
                    string noHTML = Regex.Replace(item, @"&nbsp;", "--");
                    content.Add(noHTML);
                }
            }
            catch (Exception ex)
            {
                content.Add(this.ParseException(ex.ToString()));
            }

            return content;
        }

        public List<string> ExtractOptions(string url)
        {
            List<string> content = new List<string>();
            string row = string.Empty;

            var Webget = new HtmlWeb();
            try
            {
                var doc = Webget.LoadFromWebAsync(url).Result;
                var options = doc.DocumentNode.Descendants("a")
                       .Select(e => e);
                //.Where(s => !String.IsNullOrEmpty(s));
                foreach (var item in options)
                {
                    content.Add(item.Attributes["href"].Value + "|" + item.InnerText);
                }
                //content=options.ToList<string>();
            }
            catch (Exception ex)
            {
                content.Add(this.ParseException(ex.ToString()));
            }
            return content;
        }
        public string ParseException(string s)
        {
            int a = s.IndexOf('(');
            int b = s.IndexOf(')');
            string ret = "Error";
            if (a >= 0 && b >= 0)
            {
                ret = s.Substring(a + 1, b - a - 1);
            }
            return ret;
        }
    }
}
