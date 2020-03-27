using EngstromJimmySe.Pages;
using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.SyntaxHighlighting;
//using Markdig.SyntaxHighlighting;
using Microsoft.DocAsCode.MarkdigEngine.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace EngstromJimmySe.Services
{
    public class BlogService
    {
        MarkdownPipeline pipeline;
        public BlogService()
        {

            string[] errors = null;
            string[] dependencies = null;
            Dictionary<string, string> tokens = new Dictionary<string, string>();
            Dictionary<string, string> files = new Dictionary<string, string>();
            Action<MarkdownObject> verifyAST = null;

            var actualErrors = new List<string>();
            var actualDependencies = new HashSet<string>();

            var markdownContext = new MarkdownContext(
               getToken: key => tokens.TryGetValue(key, out var value) ? value : null,
               logInfo: (a, b, c, d) => { },
               logSuggestion: Log("suggestion"),
               logWarning: Log("warning"),
               logError: Log("error"),
               readFile: ReadFile);

            pipeline = new MarkdownPipelineBuilder()
                 .UseAdvancedExtensions()
                 .UseYamlFrontMatter()
                 .UseInteractiveCode()
                 .UseSyntaxHighlighting()
                 .UseDocfxExtensions(markdownContext)
                 .Build();
          

            MarkdownContext.LogActionDelegate Log(string level)
            {
                return (code, message, origin, line) => actualErrors.Add(code);
            }

            (string content, object file) ReadFile(string path, object relativeTo, MarkdownObject origin)
            {
                string filecontent = "File not found";

                try
                {
                    filecontent=File.ReadAllText(path);
                }
                catch { }

                return (filecontent, path);
            }

        }
        
        List<BlogPost> Posts = new List<BlogPost>();
        List<string> Categories = new List<string>();
        List<string> Tags = new List<string>();

        public async Task<List<BlogPost>> GetPostsAsync(string searchterm=null)
        {
            if (searchterm != null)
            {
                searchterm = searchterm.ToLower();
            }
            await LoadPostsAsync();
            var posts = Posts.Where(p => p.Date < DateTime.Now && p.Page == false).OrderByDescending(p => p.Date).AsQueryable();
            if(searchterm!=null)
            {
                posts=posts.Where(p => p.Title.ToLower().Contains(searchterm) || p.Content.ToLower().Contains(searchterm) || p.Tags.Any(t=>t.ToLower().Contains(searchterm)) || p.Categories.Any(c => c.ToLower().Contains(searchterm)));
            }
            return posts.ToList();
        }

        public async Task<BlogPost> GetPostAsync(string permalink,bool useContains=false)
        {
            await LoadPostsAsync();
            if(useContains)
            {
                return Posts.FirstOrDefault(p => p.PermaLink.ToLower().Contains(permalink.ToLower()));
            }
            else
            {
                return Posts.FirstOrDefault(p => p.PermaLink.ToLower() == permalink.ToLower());
            }
        }


        public async Task<List<string>> GetTagsAsync()
        {
            await LoadPostsAsync();
            return Tags;
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            await LoadPostsAsync();
            return Categories;
        }

        bool loading = false;
        public async Task LoadPostsAsync(bool force=false)
        {
            if (!loading && (Posts.Count == 0 || force))
            {
                loading=true;
                Posts = new List<BlogPost>();
                var files = Directory.GetFiles("Posts");
                foreach (var f in files)
                {
                    var blogPost = new BlogPost();
                    string post = File.ReadAllText(f);
                    var document = Markdown.Parse(post, pipeline);
                    var writer = new StringWriter();
                    var renderer = new HtmlRenderer(writer);

                    pipeline.Setup(renderer);


                    var yamlBlock = document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

                    if (yamlBlock != null)
                    {
                        var yamlDeserializer = new DeserializerBuilder()
                                .WithNamingConvention(new CamelCaseNamingConvention())
                                .IgnoreUnmatchedProperties()
                                .Build();
                        var parser = new Parser(new StringReader(post));
                        parser.Consume<StreamStart>();
                        parser.Consume<DocumentStart>();
                        blogPost = yamlDeserializer.Deserialize<BlogPost>(parser);

                        parser.Consume<DocumentEnd>();
                    }

                    renderer.Render(document);

                    writer.Flush();

                    blogPost.Content = writer.ToString();
                    blogPost.PermaLink = Path.GetFileNameWithoutExtension(f);
                    Posts.Add(blogPost);
                    if (blogPost.Tags != null)
                    {
                        foreach (var t in blogPost.Tags)
                        {
                            if (!Tags.Contains(t))
                            {
                                Tags.Add(t);
                            }
                        }
                    }

                    if (blogPost.Categories!=null)
                    {
                        foreach (var c in blogPost.Categories)
                        {
                            if (!Categories.Contains(c))
                            {
                                Categories.Add(c);
                            }
                        }
                    }
                }
                loading = false;
            }
        }
    }
}
