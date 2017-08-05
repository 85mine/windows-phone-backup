using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text;

namespace VnexpressReader
{
    public enum VnExpressContentType
    {
        Tittle = 0, Lead, ImgSource, ImgCap, Content, Writer
    }
    public class VnExpressContent
    {
        public VnExpressContentType Type;
        public string Value;
    }
    public class Content2Xml
    {
        public VnExpressContent[] ContentArray;
    }
    public partial class DetailsPost : PhoneApplicationPage
    {
        public DetailsPost()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string msg = "";
            string link = "";
            if (NavigationContext.QueryString.TryGetValue("msg", out msg))
            {
                PageTitle.Text = msg;
                NavigationContext.QueryString.TryGetValue("link", out link);
                GetWebContent(link);
            }
        }
        //Lay noi dung Web
        public void GetWebContent(string strLink)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadStringAsync(new System.Uri(strLink));
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
        }
        public string contt = "";
        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show(Parser(e.Result));
                string contentsDetails = ConvertExtendedASCII(Parser(e.Result));
                WebContents.Loaded += new RoutedEventHandler(WebContents_Loaded);
                //WebContents.Navigate(new Uri(site, UriKind.Absolute));
                WebContents.NavigateToString(contentsDetails);
            }
           
        }

        void WebContents_Loaded(object sender, RoutedEventArgs e)
        {
           // WebContents.NavigateToString("<html><head><meta name='viewport' content='width=480, user-scalable=yes' /></head><body>HTML Text</body></html>");
        }

        //Lay noi dung bai viet
        public static readonly string GetAllPartern = "<H1 class=Title>(?<title>.*)</h1>|<H2 class=Lead>(?<lead>.*)</h2>|<IMG src=\"(?<imgSrc>.*.jpg)\"|<td class=\"Image\">(?<imgCap>.*)</td>|<P class=Normal[^right]*>(?<content>.*)</p>|<p class=Normal align=right><STRONG>(?<writer>.*)</STRONG></p>|<P class=Normal align=left>(?<content>.*)</p>|<p class=Normal align=right><STRONG>(?<writer>.*)</p>";
        public string Parser(string htmlContent)
        {
            string result = null;
            List<VnExpressContent> tmpList = new List<VnExpressContent>();
            Regex regex = new Regex(GetAllPartern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(htmlContent);
            bool isWriterTag = false;
            int j = 0;
            int sumLength = 0;
            int maxLength = 50000;
            while ((j < matches.Count) && (!isWriterTag))
            {
                if (matches[j].Groups["title"].Length != 0)
                {
                    VnExpressContent tmp = new VnExpressContent();
                    tmp.Type = VnExpressContentType.Tittle;
                    tmp.Value = matches[j].Groups["title"].Value;
                    tmpList.Add(tmp);
                    sumLength += tmp.Value.Length;
                    j++;
                    continue;
                }
                if (matches[j].Groups["lead"].Length != 0)
                {
                    VnExpressContent tmp = new VnExpressContent();
                    tmp.Type = VnExpressContentType.Lead;
                    tmp.Value = matches[j].Groups["lead"].Value;
                    tmp.Value = Regex.Replace(tmp.Value, @"<br>.*", "", RegexOptions.IgnoreCase);
                    tmpList.Add(tmp);
                    sumLength += tmp.Value.Length;
                    j++;
                    continue;
                }
                if (matches[j].Groups["imgSrc"].Length != 0)
                {
                    VnExpressContent tmp = new VnExpressContent();
                    tmp.Type = VnExpressContentType.ImgSource;
                    tmp.Value = matches[j].Groups["imgSrc"].Value;
                    FixImgageLink(ref tmp.Value);
                    tmpList.Add(tmp);
                    j++;
                    continue;
                }
                if (matches[j].Groups["imgCap"].Length != 0)
                {
                    if (sumLength < maxLength)
                    {
                        VnExpressContent tmp = new VnExpressContent();
                        tmp.Type = VnExpressContentType.ImgCap;
                        tmp.Value = matches[j].Groups["imgCap"].Value;
                        // Remove HTML tags. 
                        tmp.Value = Regex.Replace(tmp.Value, "<[^>]+>", string.Empty);
                        tmpList.Add(tmp);
                        sumLength += tmp.Value.Length;
                    }

                    j++;
                    continue;
                }
                if (matches[j].Groups["content"].Length != 0)
                {
                    if (sumLength < maxLength)
                    {
                        VnExpressContent tmp = new VnExpressContent();
                        tmp.Type = VnExpressContentType.Content;
                        tmp.Value = matches[j].Groups["content"].Value;
                        // Remove HTML tags. 
                        tmp.Value = Regex.Replace(tmp.Value, "<[^>]+>", string.Empty);
                        // Remove encoded HTML characters
                        tmp.Value = HttpUtility.HtmlDecode(tmp.Value);
                        //tmp.Value = Regex.Replace(tmp.Value, @"<em>", "", RegexOptions.IgnoreCase);
                        //tmp.Value = Regex.Replace(tmp.Value, @"</em>", "", RegexOptions.IgnoreCase);
                        tmpList.Add(tmp);
                        sumLength += tmp.Value.Length;
                    }
                    j++;
                    continue;
                }
                if (matches[j].Groups["writer"].Length != 0)
                {
                    isWriterTag = true;
                    VnExpressContent tmp = new VnExpressContent();
                    tmp.Type = VnExpressContentType.Writer;
                    tmp.Value = matches[j].Groups["writer"].Value;
                    tmpList.Add(tmp);
                    j++;
                    continue;
                }
            }
            Content2Xml tmpContent = new Content2Xml();
            tmpContent.ContentArray = tmpList.ToArray();

            XmlSerializer ser = new XmlSerializer(typeof(Content2Xml));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            ser.Serialize(writer, tmpContent);
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(sb.ToString());
            return sb.ToString();
        }
        private static string ConvertExtendedASCII(string HTML)
        {
            string retVal = "";
            char[] s = HTML.ToCharArray();

            foreach (char c in s)
            {
                if (Convert.ToInt32(c) > 127)
                    retVal += "&#" + Convert.ToInt32(c) + ";";
                else
                    retVal += c;
            }

            return retVal;
        }
        public void FixImgageLink(ref string Strfix)
        {
            int index;
            StringBuilder sb = new StringBuilder(Strfix);
            while (Strfix.IndexOf("/Files/") != -1)
            {
                index = Strfix.IndexOf("/Files/")+1; // +1 de tranh lap vo han
                sb.Insert(index, "http://vnexpress.net");
                Strfix = sb.ToString();
            }
        }

    }
}