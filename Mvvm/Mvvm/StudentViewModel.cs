using Mvvm.Annotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mvvm
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private string _firstName = null;

        private double _gradePointAverage = 0.0;

        private string _lastName = null;

        public event Action<StudentViewModel> DeleteStudentEvent = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public double GradePointAverage
        {
            get { return _gradePointAverage; }
            set
            {
                _gradePointAverage = value;
                OnPropertyChanged("GradePointAverage");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public void DeleteStudentAction()
        {
            if (DeleteStudentEvent != null)
                DeleteStudentEvent(this);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}