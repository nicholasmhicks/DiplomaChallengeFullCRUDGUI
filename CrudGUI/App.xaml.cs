using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CrudGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        void App_Startup (object sender, StartupEventArgs e)
        {
            _logger.Trace($"Application launched at: {DateTime.Now}");
        }
        void App_Exit(object sender, ExitEventArgs e)
        {
            _logger.Trace($"Application closed at: {DateTime.Now}");
        }
    }
}
