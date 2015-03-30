using System;
using System.Windows.Input;

namespace Command
{
    public class DelegateCommand : ICommand
    {
        private Action _executeMethod;
        private Predicate<object> _canExecuteMethod;

        public DelegateCommand(Action executeMethod, Predicate<object> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethod == null)
                return true;

            return _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethod();
        }

        public event EventHandler CanExecuteChanged;
    }
}