using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp_MVVM.Commands
{
    public class DialogCommand<T> : ICommand
    {
        private Func<object?, bool>? _canExecute;
        private Func<T> _dataContext;
        private Action<T> _positiveAction;

        public DialogCommand(Func<T> dataContext, Action<T> positiveAction, Func<object?, bool> canExecute)
        {
            _dataContext = dataContext;
            _positiveAction = positiveAction;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            Window window = (Window)Activator.CreateInstance((Type)parameter!)!;
            window.DataContext = _dataContext();
            if (window.ShowDialog() == true)
            {
                _positiveAction((T)window.DataContext!);
            }
        }
    }
}
