using System.Windows;
using System.Windows.Controls;
using TheMediator = Mediator.Helpers;

namespace Mediator
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TheMediator.Mediator.NotifyColleagues("Try1", "Hello World");
        }
    }
}