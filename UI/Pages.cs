using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuneTracker.UI
{
    class Pages
    {
        /// <summary>
        /// Registers all the UI views with the PageRegistry.
        /// </summary>
        public static void RegisterAll()
        {
            PageRegistry.Register(new AppPage("HomeScreen", new HomeScreen(), true));
        }
    }
}
