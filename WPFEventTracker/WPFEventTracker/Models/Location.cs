using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEventTracker.Models
{
    public class Location
    {
        private string _locationName;
        private string _locationOwnerFirstName;
        private string _locationOwnerLastName;
        private string _locationContactNumber;
        private Address _locationAddress;
        public Location(string locationName, string locationOwnerFirstName, string locationOwnerLastName,
            string locationContactNumber, Address locationAddress)
        {
            LocationName = locationName;
            LocationOwnerFirstName = locationOwnerFirstName;
            LocationOwnerLastName = locationOwnerLastName;
            LocationContactNumber = locationContactNumber;
            LocationAddress = locationAddress;
        }

        public Location()
        {

        }

        public string LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        public string LocationOwnerFirstName
        {
            get { return _locationOwnerFirstName; }
            set { _locationOwnerFirstName = value; }
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

        public Address LocationAddress
        {
            get { return _locationAddress; }
            set { _locationAddress = value; }
        }
    }
}
