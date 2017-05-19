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

namespace LightUser.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для BTextbox.xaml
    /// </summary>
    public partial class BTextbox : UserControl
    {
        public string Text;
        public BTextbox()
        {
            InitializeComponent();
            this.GotFocus += RemoveText;
            this.LostFocus += AddText;
            this.Text = "Enter text here...";
            Textbox.Text = "Enter text here...";
        }
        
        public void RemoveText(object sender, EventArgs e)
        {
            if (Textbox.Text == "Enter text here..." || Textbox.Text == "")
            {
                this.Text = "";
                Textbox.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Textbox.Text))
            {
                this.Text = "Enter text here...";
                Textbox.Text = "Enter text here...";
            }
        }

        private void ClearTextboxButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveText(sender, e);
        }
    }
}
