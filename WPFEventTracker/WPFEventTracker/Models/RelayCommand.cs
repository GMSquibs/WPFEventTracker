using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics.CodeAnalysis;

namespace WPFEventTracker.Models
{
    public class RelayCommand<T>: ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        public RelayCommand(Action<T> execute)
            : this(execute,null)
        { 
        
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("execute");
            }

            this._execute = execute;
            this._canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (this._canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            this._execute((T)parameter);
        }
    }

    //[SupressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
    //    Justification = "Reviewed. Suppresion is OK here. Impossible to seperate implmentation without keeping same file name.")]

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute): 
            this(execute, null)
        { 
        
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("execute");
            }

            this._execute = execute;
            this._canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add 
            {
                if (this._canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (this._canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute();
        }

        public void Execute(object parameter)
        {
            this._execute();
        }
    }
}
