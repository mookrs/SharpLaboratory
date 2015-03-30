using System.Windows;

namespace Command
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var commandSampleViewModel = new CommandViewModel();
            DataContext = commandSampleViewModel;
        }
    }
}