using System.Windows;

namespace ItemsControlDataTemplate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var studentList = new StudentListViewModel();
            studentList.TheStudents.Add(new Student { StudentFirstName = "John", StudentGradePointAverage = 3.5 });
            studentList.TheStudents.Add(new Student { StudentFirstName = "Bill", StudentGradePointAverage = 3.25 });
            studentList.TheStudents.Add(new Student { StudentFirstName = "Jim", StudentGradePointAverage = 4.0 });

            DataContext = studentList;
        }
    }
}