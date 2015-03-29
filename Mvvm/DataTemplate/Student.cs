using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataTemplate
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _firstName;

        public string StudentFirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("StudentFirstName");
            }
        }

        private double _gradePointAverage;

        public double StudentGradePointAverage
        {
            get { return _gradePointAverage; }
            set
            {
                _gradePointAverage = value;
                OnPropertyChanged("StudentGradePointAverage");
            }
        }
    }
}