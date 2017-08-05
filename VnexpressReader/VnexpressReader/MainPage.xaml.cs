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
using System.Text;
using System.Text.RegularExpressions;

namespace VnexpressReader
{
    public class Topic
    {
        public string Name{get; set;}
        public string RssLink{get; set;}
    }
    public class ListTopic : List<Topic>
    {

        public ListTopic()
        {
            this.Add(new Topic { Name = "Xã hội", RssLink = "http://vnexpress.net/rss/gl/xa-hoi.rss" });
            this.Add(new Topic { Name = "Thế giới",RssLink = "http://vnexpress.net/rss/gl/the-gioi.rss"});
            this.Add(new Topic { Name = "Kinh doanh", RssLink = "http://vnexpress.net/rss/gl/kinh-doanh.rss" });
            this.Add(new Topic { Name = "Văn hóa", RssLink = "http://vnexpress.net/rss/gl/van-hoa.rss" });
            this.Add(new Topic { Name = "Thể thao", RssLink = "http://vnexpress.net/rss/gl/the-thao.rss" });
            this.Add(new Topic { Name = "Pháp luật", RssLink = "http://vnexpress.net/rss/gl/phap-luat.rss" });
            this.Add(new Topic { Name = "Đời sống", RssLink = "http://vnexpress.net/rss/gl/doi-song.rss" });
            this.Add(new Topic { Name = "Khoa Học", RssLink = "http://vnexpress.net/rss/gl/khoa-hoc.rss" });
            this.Add(new Topic { Name = "Vi tính", RssLink = "http://vnexpress.net/rss/gl/vi-tinh.rss" });
            this.Add(new Topic { Name = "Ô tô - Xe máy", RssLink = "http://vnexpress.net/rss/gl/oto-xe-may.rss" });
            this.Add(new Topic { Name = "Cười", RssLink = "http://vnexpress.net/rss/gl/cuoi.rss" });

        }
        
    }
    public partial class MainPage : PhoneApplicationPage
    {
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            SelectCategories.ItemsSource=new ListTopic();
            SelectCategories.DisplayMemberPath = "Name";
        }


        private void SelectCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         //   MessageBox.Show(SelectCategories.SelectedItem as string);
            Topic item= SelectCategories.SelectedItem as Topic;
            NavigationService.Navigate(new Uri("/Details.xaml?msg=" + item.Name +"&link="+item.RssLink, UriKind.RelativeOrAbsolute));

        }

    }
}