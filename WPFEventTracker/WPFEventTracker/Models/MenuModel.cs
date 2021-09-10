using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEventTracker.Models
{
    public class MenuModel
    {
        private string _beverageName;
        private int _servings;
        private decimal _price;
        public MenuModel()
        {

        }

        public string BeverageName
        {
            get { return _beverageName; }
            set { _beverageName = value; }
        }

        public int Servings
        {
            get { return _servings; }
            set { _servings = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

    }
}
