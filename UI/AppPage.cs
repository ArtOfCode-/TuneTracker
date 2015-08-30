using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.IO;

namespace TuneTracker.UI
{
    public class AppPage
    {
        /// <summary>
        /// Gets or sets the name of this page.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An instance of the page.
        /// </summary>
        public UserControl Page { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this page is the default (i.e. home) page.
        /// </summary>
        public bool IsDefault { get; set; }


        /// <summary>
        /// Initialises a new instance of the AppPage class.
        /// </summary>
        public AppPage(string name, UserControl page, bool isDefault)
        {
            Name = name;
            Page = page;
            IsDefault = isDefault;
        }
    }
}
