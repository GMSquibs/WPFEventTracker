using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFEventTracker.Models;

namespace WPFEventTracker.ViewModels
{
    public class LocationManagementViewModel: INotifyPropertyChanged
    {
        private List<Location> _locations;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public LocationManagementViewModel()
        {
            Locations = new DataAccess.DatabaseAccess().GetLocations();
        }

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value;
                OnPropertyChanged();
            }
        }

    }
}
