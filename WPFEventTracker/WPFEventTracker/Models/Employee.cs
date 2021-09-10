using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEventTracker.Models
{
    public class Employee
    {
        private string _employeeFirstName;
        private string _employeeLastName;
        private string _employeeContactNumber;
        
        public Employee()
        {

        }

        public string EmployeeFirstName
        {
            get { return _employeeFirstName; }
            set { _employeeFirstName = value; }
        }

        public string EmployeeLastName
        {
            get { return _employeeLastName; }
            set { _employeeLastName = value; }
        }

        public string EmployeeContactNumber
        {
            get { return _employeeContactNumber; }
            set { _employeeContactNumber = value; }
        }
    }
}
