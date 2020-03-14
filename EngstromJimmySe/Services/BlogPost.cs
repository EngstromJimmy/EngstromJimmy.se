using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EngstromJimmySe.Services
{
    public class BlogPost
    {
        public string Title { get; set; }
        public string PermaLink { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
        public string[] Categories { get; set; }
        public string Author { get; set; }

        public bool Page { get; set; }


        public string GetFirstParagraph()
        {
            
            var m = Regex.Matches(Content, @"<p>(.*?)</p>",RegexOptions.Singleline);
            if (m.Count>0)
            {
                return m[0].Groups[1].Value;
            }
            else
            {
                return "";
            }
        }
    }
}
