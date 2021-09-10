using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFEventTracker.Models;

namespace WPFEventTracker.ViewModels
{
    class LocationManagementViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

        protected void OnPropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            this.OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        protected static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            return ((MemberExpression)action.Body).Member.Name;
        }

        public LocationManagementViewModel()
        {
            Model = new LocationModel();
            UpdateCommand = new Updater();
        }

        private LocationModel _model;

        public LocationModel Model
        {
            get { return _model; }
            set 
            { 
                _model = value;                
                OnPropertyChanged(() => Model);
            }
        }

        private ICommand _mUpdater;

        public ICommand UpdateCommand
        {
            get {
                    if (_mUpdater == null)
                    {
                        _mUpdater = new Updater();
                    }
                    return _mUpdater;
                }
            set
            {
                _mUpdater = value;            
            }
        }

        private class Updater : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parm)
            {
                return true;
            }

            public void Execute(object parm)
            { 
            
            }
        }
        


    }
}
