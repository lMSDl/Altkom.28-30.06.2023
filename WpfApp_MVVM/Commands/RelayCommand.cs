﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp_MVVM.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<object?> _execute;
        private Func<object?, bool>? _canExecute;

        public RelayCommand(Action<object?> execute)
        {
            _execute = execute;
        }
        public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute) : this(execute)
        {
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
            _execute(parameter);
        }
    }
}
