using System.Collections.ObjectModel;

namespace ItemsControlDataTemplate
{
    public class StudentListViewModel
    {
        public ObservableCollection<Student> TheStudents { get; private set; }

        public StudentListViewModel()
        {
            TheStudents = new ObservableCollection<Student>();
        }
    }
}