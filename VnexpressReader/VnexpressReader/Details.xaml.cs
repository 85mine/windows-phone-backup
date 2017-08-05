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
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.ServiceModel.Syndication;
using System.IO;
using System.Xml;
using Microsoft.Phone.Tasks;
namespace VnexpressReader
{
    public partial class Details : PhoneApplicationPage
    {
        public Details()
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
                MessageBox.Show("hghjghj");
                PageTitle.Text = msg;
                NavigationContext.QueryString.TryGetValue("link", out link);
                GetWebContent(link);
            }
            if (this.State.ContainsKey("feed"))
            {
                if (feedListBox.Items.Count == 0)
                {
                    UpdateFeedList(State["feed"] as string);
                }
            }


       }
        //Lay noi dung Web
        public void GetWebContent(string strLink)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadStringAsync(new System.Uri(strLink));
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
        }
        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                this.State["feed"] = e.Result;
                UpdateFeedList(e.Result);
            }
        }
        private void UpdateFeedList(string feedXML)
        {
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                feedListBox.ItemsSource = feed.Items;
            });

        }
        private void feedListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;

            if (listBox != null && listBox.SelectedItem != null)
            {
                SyndicationItem sItem = (SyndicationItem)listBox.SelectedItem;

                if (sItem.Links.Count > 0)
                {
                    Uri uri = sItem.Links.FirstOrDefault().Uri;
                    string Title = sItem.Title.Text;
                    WebBrowserTask webBrowserTask = new WebBrowserTask();
                    NavigationService.Navigate(new Uri("/DetailsPost.xaml?msg=" + Title + "&link=" + uri, UriKind.RelativeOrAbsolute));
                   // webBrowserTask.Uri = uri;
                   // webBrowserTask.Show();
                }
            }
        }

    }
}