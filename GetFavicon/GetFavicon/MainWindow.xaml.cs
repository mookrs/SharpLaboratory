using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GetFavicon
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly List<string> Domains = new List<string>()
        {
            "baidu.com",
            "zhihu.com",
            "fanfou.com",
            "v2ex.com",
            "163.com",
            "sina.com.cn"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetFaviconsButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (string domain in Domains)
            {
                AddFavicon(domain);
            }
        }

        private void AddFavicon(string domain)
        {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += OnWebClient_DownloadDataCompleted;
            webClient.DownloadDataAsync(new Uri("http://" + domain + "/favicon.ico"));
        }

        // 这个版本有bug，因为图标出现的顺序是按下载快慢来排的
        private void OnWebClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Image imageControl = MakeImageControl(e.Result);
            FaviconsPanel.Children.Add(imageControl);
        }

        private Image MakeImageControl(byte[] bytes)
        {
            Image imageControl = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            imageControl.Source = bitmapImage;
            imageControl.Width = 16;
            imageControl.Height = 16;
            return imageControl;
        }
    }
}