using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace UniFIIcation.Services
{
    public class ParseWeb : IMyParseWeb
    {
        public List<string> ExtractContent(string url)
        {
            var content = new List<string>();
            var row = string.Empty;

            var Webget = new HtmlWeb();
            try
            {
                var doc = Webget.LoadFromWebAsync(url).Result;
                var headers = doc.DocumentNode.Descendants("th")
                    .Select(e => e.InnerText);
                //.Where(s => !String.IsNullOrEmpty(s));
                content = headers.ToList();

                var data = doc.DocumentNode.Descendants("td")
                    .Select(e => e.InnerText);

                foreach (var item in data)
                {
                    var noHTML = Regex.Replace(item, @"&nbsp;", "--");
                    content.Add(noHTML);
                }
            }
            catch (Exception ex)
            {
                content.Add(ParseException(ex.ToString()));
            }

            return content;
        }

        public List<string> ExtractOptions(string url)
        {
            var content = new List<string>();
            var row = string.Empty;

            var Webget = new HtmlWeb();
            try
            {
                var doc = Webget.LoadFromWebAsync(url).Result;
                var options = doc.DocumentNode.Descendants("a")
                    .Select(e => e);
                //.Where(s => !String.IsNullOrEmpty(s));
                foreach (var item in options)
                    content.Add(item.Attributes["href"].Value + "|" + item.InnerText);
                //content=options.ToList<string>();
            }
            catch (Exception ex)
            {
                content.Add(ParseException(ex.ToString()));
            }
            return content;
        }

        public string ParseException(string s)
        {
            var a = s.IndexOf('(');
            var b = s.IndexOf(')');
            var ret = "Error";
            if (a >= 0 && b >= 0)
                ret = s.Substring(a + 1, b - a - 1);
            return ret;
        }
    }
}