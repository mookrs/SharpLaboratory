using System.Windows;

namespace Binding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Student _student = new Student
        {
            StudentFirstName = "John", StudentGradePointAverage = 3.5
        };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _student;
        }
    }
}