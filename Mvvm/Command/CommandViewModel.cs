using System.Windows;

namespace Command
{
    public class CommandViewModel
    {
        public DelegateCommand TheCommand { get; private set; }

        public CommandViewModel()
        {
            TheCommand = new DelegateCommand(OnExecute, CanExecute);
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }

        private void OnExecute()
        {
            MessageBox.Show("Command Executed");
        }
    }
}