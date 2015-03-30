using Mvvm.Annotations;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mvvm
{
    public class StudentListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Func<ObservableCollection<StudentViewModel>> GetStudentsDelegate = null;
        public Action<ObservableCollection<StudentViewModel>> SaveStudentsDelegate = null;

        private ObservableCollection<StudentViewModel> _theStudents = null;

        public ObservableCollection<StudentViewModel> TheStudents
        {
            get { return _theStudents; }
            set
            {
                if (_theStudents == value)
                    return;

                if (_theStudents != null)
                {
                    foreach (var studentViewModel in _theStudents)
                    {
                        DisconnectStudentViewModel(studentViewModel);
                    }
                }

                _theStudents = value;

                if (_theStudents != null)
                {
                    foreach (var studentViewModel in _theStudents)
                    {
                        ConnectStudentViewModel(studentViewModel);
                    }
                }

                OnPropertyChanged("TheStudents");
            }
        }

        private void Student_DeleteStudentEvent(StudentViewModel StudentViewModel)
        {
            DisconnectStudentViewModel(StudentViewModel);
            TheStudents.Remove(StudentViewModel);
        }

        private void ConnectStudentViewModel(StudentViewModel StudentViewModel)
        {
            StudentViewModel.DeleteStudentEvent += Student_DeleteStudentEvent;
        }

        private void DisconnectStudentViewModel(StudentViewModel StudentViewModel)
        {
            StudentViewModel.DeleteStudentEvent -= Student_DeleteStudentEvent;
        }

        public void GetStudentsAction()
        {
            TheStudents = GetStudentsDelegate();

            IsSaveStudentsActionEnabled = true;
            IsAddStudentsActionEnabled = true;
        }

        private bool _isSaveStudentsActionEnabled = false;

        public bool IsSaveStudentsActionEnabled
        {
            get { return _isSaveStudentsActionEnabled; }
            set
            {
                _isSaveStudentsActionEnabled = value;

                OnPropertyChanged("IsSaveStudentsActionEnabled");
            }
        }

        public void SaveStudentsAction()
        {
            if (SaveStudentsDelegate != null)
                SaveStudentsDelegate(TheStudents);
        }

        private bool _isAddStudentsActionEnabled = false;

        public bool IsAddStudentsActionEnabled
        {
            get { return _isAddStudentsActionEnabled; }
            set
            {
                _isAddStudentsActionEnabled = value;

                OnPropertyChanged("IsAddStudentsActionEnabled");
            }
        }

        public void AddStudentAction()
        {
            var newStudentVm = new StudentViewModel { FirstName = null, LastName = null };

            ConnectStudentViewModel(newStudentVm);

            TheStudents.Add(newStudentVm);
        }
    }
}