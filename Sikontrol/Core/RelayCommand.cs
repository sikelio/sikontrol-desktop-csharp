using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sikontrol.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canFunc;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute= execute;
            _canFunc= canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canFunc == null || _canFunc(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
