﻿using System.Collections.ObjectModel;

namespace Mvvm
{
    public class MockServerProxy
    {
        private ObservableCollection<StudentViewModel> _students = new ObservableCollection<StudentViewModel>();

        public ObservableCollection<StudentViewModel> GetStudents()
        {
            return _students;
        }

        public void SaveStudents(ObservableCollection<StudentViewModel> students)
        {
            _students = students;
        }

        public MockServerProxy()
        {
            _students.Add(new StudentViewModel { FirstName = "John", LastName = "Smith", GradePointAverage = 3.75 });
            _students.Add(new StudentViewModel { FirstName = "Kathy", LastName = "Green", GradePointAverage = 4.0 });
        }
    }
}