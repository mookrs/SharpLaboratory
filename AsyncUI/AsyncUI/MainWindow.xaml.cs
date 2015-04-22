using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AsyncButton_Click(object sender, RoutedEventArgs e)
        {
            MyTextBox.Text = await CalculateTextAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I can be clicked!");
        }

        private async Task<string> CalculateTextAsync()
        {
            return await Task.Run(() =>
            {
                int x = 0;
                for (int i = 0; i < 1000000000; i++)
                {
                    x = i;
                }
                return x.ToString();
            });
        }
    }
}
