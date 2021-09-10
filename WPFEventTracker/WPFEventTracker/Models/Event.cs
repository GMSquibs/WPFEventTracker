using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEventTracker.Models
{
    public class Event
    {
        private DateTime _eventDate;
        private TimeSpan _eventTime;
        private Location _eventLocation;
        private Client _client;
        private List<Employee> _employeesWorkingEvent;
        private List<Menu> _eventMenu;
        private string _eventNotes;
        private decimal _eventCost;
        private int _headCount;

        public Event()
        {

        }

        public DateTime EventDate
        {
            get { return _eventDate; }
            set { _eventDate = value; }
        }

        public TimeSpan EventTime
        {
            get { return _eventTime; }
            set { _eventTime = value; }
        }

        public Location EventLocation
        {
            get { return _eventLocation; }
            set { _eventLocation = value; }
        }

        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public List<Menu> EventMenu
        {
            get { return _eventMenu; }
            set { _eventMenu = value; }
        }

        public List<Employee> EmployeesWorkingEvent
        {
            get { return _employeesWorkingEvent; }
            set { _employeesWorkingEvent = value; }
        }

        public string EventNotes
        {
            get { return _eventNotes; }
            set { _eventNotes = value; }
        }

        public decimal EventCost
        {
            get { return _eventCost; }
            set { _eventCost = value; }
        }

        public int HeadCount
        {
            get { return _headCount; }
            set { _headCount = value; }
        }
    }
}
