using System.Windows;
using System.Windows.Controls;
using LightUser.CommandService;
using LightUser.Data;

namespace LightUser.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        Contact contact = new Contact();
        public Card()
        {
            InitializeComponent();
        }

        public void SetContact(Contact newcontact)
        {
            contact = newcontact;

            if (contact.Number.Count > 0)
            {
                NameTextBlock.Text = contact.Number[0];
            }


            //if (newcontact.Name.Contains(" "))
            //{
            //    var name = contact.Name.Split(' ');
            //    nameLabel.Text = name[0];
            //    if (name.Length > 1)
            //        SecondName.Text = name[1];
            //}
            //else
            //{
            //    nameLabel.Text = newcontact.Name;
            //    SecondName.Text = string.Empty;
            //}
            //FirstNumber.Text = newcontact.Prefix + newcontact.Number;
            //SecondNumber.Text = newcontact.SecondNumber;
            //if (string.IsNullOrEmpty(SecondNumber.Text))
            //{
            //    try
            //    {
            //        SecondNumber.Text = Localization[SecondNumber.Name][1];
            //    }
            //    catch
            //    {
            //        SecondNumber.Text = "Неизвестно";
            //    }
            //}
            //menunumber1.Text = newcontact.Number;
            //if (!string.IsNullOrEmpty((newcontact.SecondNumber)))
            //    if (позвонитьToolStripMenuItem.DropDownItems.Count == 1)
            //    {
            //        add_toolstripNumber2(newcontact.SecondNumber);
            //    }
            //    else
            //    {
            //        menunumber2.Text = newcontact.SecondNumber;
            //    }
            //else
            //{
            //    if (позвонитьToolStripMenuItem.DropDownItems.Count > 1)
            //        позвонитьToolStripMenuItem.DropDownItems.Remove(позвонитьToolStripMenuItem.DropDownItems[1]);
            //    //menunumber2.Text = "Не указан";
            //}
            /////Автарка
            //ImageLoader img = new ImageLoader(contact);
            //if (img.IsImageExists())
            //{
            //    avatar.BackgroundImage = img.CircleImage(Color.Transparent);
            //}
            //else avatar.BackgroundImage = img.CircleImage(imageList1.Images[0], Color.Transparent);

            //buttonDown.BackColor = Color.Transparent;
            //buttonUp.BackColor = Color.Transparent;
            //UpdateStatus();

            /////Подсказки для кнопок
            //Tip.SetToolTip(nameLabel, newcontact.Name);
            //Tip.SetToolTip(SecondName, newcontact.Name);
        }

        private void CallButton_OnClick(object sender, RoutedEventArgs e)
        {
            CommandDispatcher.Call("101");
        }
    }
}
