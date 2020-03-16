using EngstromJimmySe.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EngstromJimmySe.Controllers
{
    public class FeedController:Controller
    {
        BlogService blogService;
        AppStateService appStateService;
        public FeedController(BlogService blogService, AppStateService appStateService)
        {
            this.blogService = blogService;
            this.appStateService = appStateService;
        }

        [ResponseCache(Duration = 1200)]
        [HttpGet]
        public async Task<IActionResult> Rss()
        {
            var feed = new SyndicationFeed(appStateService.Configuration.FeedTitle, appStateService.Configuration.FeedDescription, new Uri(appStateService.Configuration.FeedSiteUrl,UriKind.Absolute), appStateService.Configuration.FeedId, DateTime.Now);

            feed.Copyright = new TextSyndicationContent(appStateService.Configuration.FeedCopyright);
            var items = new List<SyndicationItem>();
            var postings = await blogService.GetPostsAsync();
            foreach (var item in postings)
            {
                var postUrl = appStateService.Configuration.FeedSiteUrl + "/" +  item.PermaLink;
                var title = item.Title;
                var description = item.GetFirstParagraph();
                items.Add(new SyndicationItem(title, description, new Uri(postUrl,UriKind.Absolute), item.PermaLink, item.Date));
            }

            feed.Items = items;
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                NewLineHandling = NewLineHandling.Entitize,
                NewLineOnAttributes = true,
                Indent = true
            };
            using (var stream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    var rssFormatter = new Rss20FeedFormatter(feed, false);
                    rssFormatter.WriteTo(xmlWriter);
                    xmlWriter.Flush();
                }
                return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
            }
        }
    }
}
