using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;
using TQDK;

namespace BalHesablayici
{
    public partial class RssPage : PhoneApplicationPage
    {
        WebClient client = new WebClient();
        private const string BlogRssUrl = "http://tqdk.gov.az/news/rss/index.php";

        public RssPage()
        {
            InitializeComponent();
            Loaded += RssPage_Loaded;
        }

        void RssPage_Loaded(object sender, RoutedEventArgs e)
        {
            client.DownloadStringCompleted += ClientDownloadStringCompleted;
            client.DownloadStringAsync(new Uri(BlogRssUrl));

            SystemTray.ProgressIndicator.IsVisible = true;
            SystemTray.ProgressIndicator.Text = "Yüklənir...";
        }

        private void ClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                ParseRss(e.Result);
                SystemTray.ProgressIndicator.IsVisible = false;
            }
        }

        private void ParseRss(string rss)
        {
            var rssElements = XElement.Parse(rss);
            var blogPosts = from post in rssElements.Descendants("item")
                            select new PostMessage
                            {
                                Title = GetElemValue(post, "title"),
                                PubDate = DateTime.Parse(GetElemValue(post, "pubDate")),
                                Link = GetElemValue(post, "link"),
                                Description = GetElemValue(post, "description")
                            };

            PostList.ItemsSource = blogPosts;
        }

        private static string GetElemValue(XElement element, string name)
        {
            var elem = element.Element(name);

            try
            {
                elem.Value = elem.Value.ToString().Replace("<br />", "");
                elem.Value = elem.Value.ToString().Replace("&nbsp;", " ");
                elem.Value = elem.Value.ToString().Replace("&#41;", " ");
                elem.Value = elem.Value.ToString().Replace("&#40;", " ");
                elem.Value = elem.Value.ToString().Replace("&quot;", " ");
                elem.Value = elem.Value.ToString().Replace("<p>", "");
                elem.Value = elem.Value.ToString().Replace("</p>", "");
                elem.Value = elem.Value.ToString().Replace("<td>", "");
                elem.Value = elem.Value.ToString().Replace("<tr>", "");
                elem.Value = elem.Value.ToString().Replace("<b>", "");
                elem.Value = elem.Value.ToString().Replace("</td>", "");
                elem.Value = elem.Value.ToString().Replace("</tr>", "");
                elem.Value = elem.Value.ToString().Replace("<tbody>", "");
                elem.Value = elem.Value.ToString().Replace("</tbody>", "");
                elem.Value = elem.Value.ToString().Replace("<p align=\"center\">", "");
                elem.Value = elem.Value.ToString().Replace("   ", "");
                elem.Value = elem.Value.ToString().Replace("</a>", "");
                elem.Value = elem.Value.ToString().Replace("&ccedil;", " ");
                elem.Value = elem.Value.ToString().Replace("&uuml;", " ");
                elem.Value = elem.Value.ToString().Replace("&ouml;", " ");
                elem.Value = elem.Value.Trim();
            }
            catch { }

            return elem == null ? null : elem.Value;
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.CancelAsync();
        }
    }
}