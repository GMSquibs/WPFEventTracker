using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFEventTracker.DataAccess;

namespace WPFEventTracker.Models
{
    public class LocationModel: INotifyPropertyChanged
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
    
        private string _locationName;
        private string _locationOwnerFirstName;
        private string _locationOwnerLastName;
        private string _locationContactNumber;
        private AddressModel _locationAddress;
        private DataTable _locations;
        public LocationModel(string locationName, string locationOwnerFirstName, string locationOwnerLastName,
            string locationContactNumber, AddressModel locationAddress)
        {
            LocationName = locationName;
            LocationOwnerFirstName = locationOwnerFirstName;
            LocationOwnerLastName = locationOwnerLastName;
            LocationContactNumber = locationContactNumber;
            LocationAddress = locationAddress;
        }

        public LocationModel()
        {
            Locations = new DatabaseAccess().GetLocations();
            UpdateLocationTableCommand = new RelayCommand(UpdateLocation,IsAuthorized);
            DeleteLocationTableCommand = new RelayCommand(DeleteLocation, IsAuthorized);
            CreateLocationTableCommand = new RelayCommand(CreateLocation, IsAuthorized);
        }

        public bool IsAuthorized()
        {
            //TODO Add in authorization logic
            return true;
        }

        private RelayCommand _deleteLocationTableCommand;
        public RelayCommand DeleteLocationTableCommand
        {
            get { return _deleteLocationTableCommand; }
            set 
            { 
                _deleteLocationTableCommand = value;
                OnPropertyChanged(() => DeleteLocationTableCommand);
            }
        }

        private RelayCommand _createLocationTableCommand;
        public RelayCommand CreateLocationTableCommand
        {
            get { return _createLocationTableCommand; }
            set
            {
                _createLocationTableCommand = value;
                OnPropertyChanged(() => CreateLocationTableCommand);
            }
        }

        private RelayCommand _updateLocationTableCommand;
        public RelayCommand UpdateLocationTableCommand
        {
            get { return _updateLocationTableCommand; }
            set
            {
                _updateLocationTableCommand = value;
                OnPropertyChanged(() => UpdateLocationTableCommand);
            }
        }

        public string LocationName
        {
            get { return _locationName; }
            set
            {
                _locationName = value;                
            }
        }

        public string LocationOwnerFirstName
        {
            get { return _locationOwnerFirstName; }
            set 
            { 
                _locationOwnerFirstName = value;                
            }
        }

        public string LocationOwnerLastName
        {
            get { return _locationOwnerLastName; }
            set { _locationOwnerLastName = value; }
        }

        public string LocationContactNumber
        {
            get { return _locationContactNumber; }
            set { _locationContactNumber = value; }
        }

        public AddressModel LocationAddress
        {
            get { return _locationAddress; }
            set { _locationAddress = value; }
        }

        public DataTable Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                OnPropertyChanged(() => Locations);
            }
        }

        public void UpdateLocation()
        { 
        
        }

        public void DeleteLocation()
        {

        }

        public void CreateLocation()
        {

            using (DatabaseAccess createNewLocation = new DatabaseAccess())
            {
                createNewLocation.CreateLocation
                    (
                     this.LocationName,
                     this.LocationOwnerFirstName,
                     this.LocationOwnerLastName,
                     this.LocationContactNumber,
                     "Address1",
                     "Address2",
                     "City",
                     "State",
                     "ZipCode"
                     );
            }
        }
    }
}
