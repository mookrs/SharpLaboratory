using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LayoutBasic
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

        private void MainWindow_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Title = "Source = " + e.Source.GetType().Name + ", OriginalSource = " + e.OriginalSource.GetType().Name +
                         " @ " + e.Timestamp;

            var source = e.Source as Control;

            if (source != null && source.BorderThickness != new Thickness(5))
            {
                source.BorderThickness = new Thickness(5);
                source.BorderBrush = Brushes.Black;
            }
            else
            {
                if (source != null) source.BorderThickness = new Thickness(0);
            }
        }
    }
}
