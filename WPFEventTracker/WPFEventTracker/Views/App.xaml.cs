using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFEventTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LocationManagement window = new LocationManagement();
            ViewModels.LocationManagementViewModel vm = new ViewModels.LocationManagementViewModel();
            window.DataContext = vm;
            window.Show();
        }
    }
}
