using System.Windows;

namespace Mvvm
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentListViewModel _studentListViewModel = new StudentListViewModel();

        public MainWindow()
        {
            InitializeComponent();

            var mockServerProxy = new MockServerProxy();

            _studentListViewModel.GetStudentsDelegate = mockServerProxy.GetStudents;
            _studentListViewModel.SaveStudentsDelegate = mockServerProxy.SaveStudents;

            DataContext = _studentListViewModel;
        }
    }
}