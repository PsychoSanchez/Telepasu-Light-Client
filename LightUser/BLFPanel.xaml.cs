using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using LightUser.CommandService;
using LightUser.CustomControls;
using LightUser.Events.EventArgs;

namespace LightUser
{
    /// <summary>
    /// Логика взаимодействия для BLFPanel.xaml
    /// </summary>
    public partial class BlfPanel
    {
        public BlfPanel()
        {
            InitializeComponent();
            
            //Spinner.Visibility = Visibility.Visible;

            CommandDispatcher.ConnectSucceded += CommandDispatcher_ConnectSucceded;
            CommandDispatcher.ConnectToProxy();
        }

        private void CommandDispatcher_ConnectSucceded(object sender, ConnectEventArgs e)
        {
            if (e.Connected)
            {
                CommandDispatcher.OnAuthOver += CommandDispatcher_OnAuthOver;
                CommandDispatcher.SendAuthMessage("light", "hjok123");
            }
            else
            {
                BlfNumberLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                BlfStatusLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                BlfNumberLabel.Text = "...";
            }
        }

        private void CommandDispatcher_OnAuthOver(object sender, Events.EventArgs.AuthEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                switch (e.AuthResponse.Status)
                {
                    case 200:
                        BlfNumberLabel.Background = new SolidColorBrush(Colors.Green);
                        BlfStatusLabel.Background = new SolidColorBrush(Colors.Green);
                        BlfStatusLabel.Text = e.AuthResponse.Status.ToString();
                        BlfNumberLabel.Text = "101";
                        break;
                    case 401:
                        BlfNumberLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                        BlfStatusLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                        BlfStatusLabel.Text = e.AuthResponse.Status.ToString();
                        BlfNumberLabel.Text = "101";
                        break;
                    case 404:
                        BlfNumberLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                        BlfStatusLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                        BlfStatusLabel.Text = e.AuthResponse.Status.ToString();
                        BlfNumberLabel.Text = "101";
                        break;
                    case 408:
                        BlfNumberLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                        BlfStatusLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                        BlfStatusLabel.Text = e.AuthResponse.Status.ToString();
                        BlfNumberLabel.Text = "101";
                        break;
                    default:
                        BlfNumberLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                        BlfStatusLabel.Background = new SolidColorBrush(Color.FromRgb(255, 128, 128));
                        BlfStatusLabel.Text = e.AuthResponse.Status.ToString();
                        BlfNumberLabel.Text = "101";
                        break;
                }
            });

            CommandDispatcher.ContactsLoaded += CommandDispatcher_ContactsLoaded;
            CommandDispatcher.GetContacts("onBlf", true.ToString());
        }

        private void CommandDispatcher_ContactsLoaded(object sender, GetContactsEventArgs e)
        {
            var contactsOnBlf = e.ContactList;

            foreach (var contact in contactsOnBlf)
            {
                var card = new Card();
                card.SetContact(contact);
                CardsPanel.Children.Add(card);
            }

            Spinner.Visibility = Visibility.Hidden;
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var splash = new Splash();
            splash.Show();
        }
    }
}
