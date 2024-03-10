﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpotifyGlobalHotkey.Utilities
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        public RelayCommand(Action<object> excute, Func<object, bool> canExecute = null)
        {
            _execute = excute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        
        public void Execute(object parameter) => _execute(parameter);
    
    }
}