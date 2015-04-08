using TheMediator = Mediator.Helpers;
using System.Windows;

namespace Mediator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TheMediator.Mediator.Register("Try1", MyMethod1);
            TheMediator.Mediator.Register("Try1", MyMethod1);   // Does not get added

            TheMediator.Mediator.Register("Try1", MyMethod2);   // Same key, different delegate

            TheMediator.Mediator.Register("Try1", MyMethod3);
            TheMediator.Mediator.Unregister("Try1", MyMethod3); // To test if unregister worked

            TheMediator.Mediator.Register("Try4", MyMethod4);   // This key is never called
        }

        private static void MyMethod1(object args)
        {
            MessageBox.Show("MyMethod1 - " + args);
        }

        private static void MyMethod2(object args)
        {
            MessageBox.Show("MyMethod2 - " + args);
        }

        private static void MyMethod3(object args)
        {
            MessageBox.Show("MyMethod3 - " + args);
        }

        private static void MyMethod4(object args)
        {
            MessageBox.Show("MyMethod4 - " + args);
        }
    }
}