using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TuneTracker.Modules;
using WMPLib;

namespace TuneTracker.Controls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        /// <summary>
        /// Gets or sets the current track.
        /// </summary>
        public AudioTrack CurrentTrack
        {
            get 
            { 
                return CurrentTrack; 
            }
            set
            {
                CurrentTrack = value;
                if (value.AudioFileType == "mp3")
                {
                    Player = new WindowsMediaPlayer();
                    WindowsMediaPlayer tempPlayer = (WindowsMediaPlayer)Player;
                    tempPlayer.URL = value.AudioFileLocation;
                    tempPlayer.controls.pause();
                }
                else
                {
                    Player = new SoundPlayer(value.AudioFileLocation);
                }
            }
        }

        /// <summary>
        /// Gets or sets the object used to play the sound.
        /// </summary>
        public object Player { get; private set; }

        /// <summary>
        /// Initialises a new instance of the PlayerControl class.
        /// </summary>
        public PlayerControl()
        {
            InitializeComponent();
            this.SetButtonStyles();
        }

        private void SetButtonStyles()
        {
            Regex nameMatch = new Regex(@"^[A-Z][a-z]+Button$");
            Regex buttonName = new Regex(@"^[A-Z][a-z]+");
            Dictionary<string, Style> buttonStyles = new Dictionary<string, Style>();
            foreach (Button button in FindVisualChildren<Button>(Controls))
            {
                if (nameMatch.Match(button.Name).Success)
                {
                    string name = buttonName.Match(button.Name).Value;

                    Style style = new Style();
                    style.TargetType = typeof(Button);
                    style.BasedOn = Controls.FindResource("ControlButtonStyle") as Style;

                    style.Setters.Add(new Setter(Button.BackgroundProperty, Controls.FindResource(name + "ButtonStandard")));

                    Trigger trigger = new Trigger();
                    trigger.Property = Button.IsMouseOverProperty;
                    trigger.Value = true;
                    trigger.Setters.Add(new Setter(Button.BackgroundProperty, Controls.FindResource(name + "ButtonHover")));
                    style.Triggers.Add(trigger);

                    buttonStyles.Add(button.Name, style);
                }
            }
            foreach (KeyValuePair<string, Style> kvp in buttonStyles)
            {
                ((Button)this.FindName(kvp.Key)).Style = kvp.Value;
            }
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
