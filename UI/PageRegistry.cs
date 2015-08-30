using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneTracker.Exceptions;

namespace TuneTracker.UI
{
    class PageRegistry
    {
        private static List<AppPage> _pages = new List<AppPage>();

        /// <summary>
        /// Registers a UI view for later access.
        /// </summary>
        /// <param name="page">The AppPage object representing the UI view.</param>
        public static void Register(AppPage page)
        {
            _pages.Add(page);
        }

        /// <summary>
        /// Registers multiple UI views for later access.
        /// </summary>
        /// <param name="pages">The AppPage objects to register.</param>
        public static void Register(params AppPage[] pages)
        {
            foreach (AppPage page in pages)
            {
                _pages.Add(page);
            }
        }

        /// <summary>
        /// Gets the AppPage identified as the default UI view.
        /// </summary>
        /// <returns>An AppPage containing the details of the default view.</returns>
        public static AppPage GetDefaultPage()
        {
            List<AppPage> page = (from AppPage selected in _pages
                                  where selected.IsDefault
                                  select selected).ToList<AppPage>();
            if (page.Count() > 1)
            {
                throw new AppPageException("More than one default page was found.");
            }
            if (page.Count() == 0)
            {
                throw new AppPageException("No default page was found.");
            }
            return page[0];
        }

        /// <summary>
        /// Gets the AppPage identified by its unique name.
        /// </summary>
        /// <param name="name">The name of the view to look for.</param>
        /// <returns>An AppPage containing the details of the named view.</returns>
        public static AppPage GetPage(string name)
        {
            List<AppPage> page = (from AppPage selected in _pages
                                  where selected.Name == name
                                  select selected).ToList<AppPage>();
            if (page.Count() > 1)
            {
                throw new AppPageException("More than one page with the same name was found.");
            }
            if (page.Count() == 0)
            {
                throw new AppPageException("No page with the specified name was found.");
            }
            return page[0];
        }
    }
}
