using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TuneTracker.Controls;

namespace TuneTracker.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Publically represents the PlayerControl used in this window.
        /// </summary>
        public PlayerControl PlayerControls;

        /// <summary>
        /// Initialises a new instance of the MainWindow class, and prepares it for display.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Pages.RegisterAll();
            this.ChangeScreen(PageRegistry.GetDefaultPage());
            App.Settings["MainWindow"] = this;
            PlayerControls = Player;
        }

        /// <summary>
        /// Changes the view to another page.
        /// </summary>
        /// <param name="page">The AppPage object to change the view to.</param>
        public void ChangeScreen(AppPage page)
        {
            ViewContainer.Content = page.Page;
        }

        /// <summary>
        /// Changes the view to another page.
        /// </summary>
        /// <param name="name">The name of the view to change to.</param>
        public void ChangeScreen(string name)
        {
            this.ChangeScreen(PageRegistry.GetPage(name));
        }

        /// <summary>
        /// Changes the status displayed in the bottom status bar.
        /// </summary>
        /// <param name="status">The new status to display.</param>
        public void ChangeStatus(string status)
        {
            CurrentStatus.Content = status;
        }

        private void Player_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
