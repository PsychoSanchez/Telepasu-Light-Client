using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using LightUser.CommandService;
using LightUser.CustomControls;
using LightUser.Events.EventArgs;
using LightUser.Data;

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

            Contact asd = new Contact();
            asd.Id = Guid.Parse("dd6f1175-b76e-4f8b-a451-f1e07f093a24");
            asd.Number.Add("123");
            asd.Name.Add("ASd sad");

            var cd = new Card();
            cd.SetContact(asd);
            cd.Margin = new Thickness(0, 5, 0, 0);
            var cd1 = new Card();
            cd1.SetContact(asd);
            cd1.Margin = new Thickness(0, 5, 0, 0);
            var cd2 = new Card();
            cd2.SetContact(asd);
            cd2.Margin = new Thickness(0, 5, 0, 0);
            var cd3 = new Card();
            cd3.SetContact(asd);
            cd3.Margin = new Thickness(0, 5, 0, 0);
            var cd4 = new Card();
            cd4.SetContact(asd);
            cd4.Margin = new Thickness(0, 5, 0, 0);
            var cd5 = new Card();
            cd5.SetContact(asd);
            cd5.Margin = new Thickness(0, 5, 0, 0);
            var cd6 = new Card();
            cd6.SetContact(asd);
            cd6.Margin = new Thickness(0, 5, 0, 0);

            CardsPanel.Children.Add(cd);
            CardsPanel.Children.Add(cd1);
            CardsPanel.Children.Add(cd2);
            CardsPanel.Children.Add(cd3);
            CardsPanel.Children.Add(cd4);
            CardsPanel.Children.Add(cd5);
            CardsPanel.Children.Add(cd6);

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
