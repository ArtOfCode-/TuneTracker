using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using System.IO;

namespace TuneTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Contains all the application-global settings. Some are set at different points. This dictionary should
        /// not be dynamically augmented.
        /// </summary>
        public static Dictionary<string, object> Settings = new Dictionary<string, object>
        {
            { "WorkingDirectory", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) },
            { "MainWindow", null }
        };
    }
}
