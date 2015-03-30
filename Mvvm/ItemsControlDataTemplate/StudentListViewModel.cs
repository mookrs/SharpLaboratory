using System.Collections.ObjectModel;

namespace ItemsControlDataTemplate
{
    public class StudentListViewModel
    {
        public StudentListViewModel()
        {
            TheStudents = new ObservableCollection<Student>();
        }

        public ObservableCollection<Student> TheStudents { get; private set; }
    }
}