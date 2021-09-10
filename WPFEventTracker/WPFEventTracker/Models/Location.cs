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
        private string _locationOwnerSecondName;
        private string _locationContactNumber;
        private Address _locationAddress;
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

        public string LocationOwnerSecondName
        {
            get { return _locationOwnerSecondName; }
            set { _locationOwnerSecondName = value; }
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
