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
            AddRemainingFavicons(Domains, 0);
        }

        private void AddRemainingFavicons(List<string> domains, int i)
        {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += (o, e) =>
            {
                Image imageControl = MakeImageControl(e.Result);
                FaviconsPanel.Children.Add(imageControl);

                if (i + 1 < domains.Count)
                {
                    AddRemainingFavicons(domains, i + 1);
                }
            };
            webClient.DownloadDataAsync(new Uri("http://" + domains[i] + "/favicon.ico"));
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