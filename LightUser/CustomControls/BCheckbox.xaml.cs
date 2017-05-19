using LightUser.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class BCheckbox : UserControl
    {
        #region Variables
        public bool Checked = false;
        public event EventHandler Checked_Changed;
        public string Text = string.Empty;
        #endregion
        #region Конструкторы
        public BCheckbox()
        {
            InitializeComponent();
            UserInterfaceAPI.InitFonts(this);
        }
        public BCheckbox(bool IsChecked, string _Text)
        {
            this.IsEnabledChanged += BCheckbox_EnabledChanged;
            Checked = IsChecked;
            if (Checked)
            {
                //CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
                CheckBoxPanel.Style = this.FindResource("CheckedCheckbox") as Style;
            }
            else
            {
                //CheckBoxPanel.BackColor = SystemColors.ButtonHighlight;
                CheckBoxPanel.Style = this.FindResource("NotCheckedCheckbox") as Style;
            }
            InitializeComponent();
            CheckBoxText.Text = _Text;
            UserInterfaceAPI.InitFonts(this);
        }
        #endregion
        #region Handlers

        private void BCheckbox_EnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsEnabled)
            {
                if (Checked)
                {
                    //CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
                    CheckBoxPanel.Style = this.FindResource("CheckedCheckbox") as Style;
                    //CheckBoxText.ForeColor = SystemColors.ControlText;
                    CheckBoxText.Foreground = SystemColors.ControlTextBrush;
                }
                else
                {
                    //CheckBoxPanel.BackColor = SystemColors.ButtonHighlight;
                    CheckBoxPanel.Style = this.FindResource("NotCheckedCheckbox") as Style;
                    //CheckBoxText.ForeColor = SystemColors.ControlText;
                    CheckBoxText.Foreground = SystemColors.ControlTextBrush;
                }
            }
            else
            {
                if (Checked)
                {
                    //CheckBoxPanel.BackColor = Color.FromArgb(200, 217, 255);
                    CheckBoxPanel.Background = new SolidColorBrush(Color.FromRgb(200, 217, 255));
                    //CheckBoxText.ForeColor = Colors.WhiteTheme.MainColor;
                    CheckBoxText.Foreground = new SolidColorBrush(Color.FromRgb(227, 227, 227));
                }
                else
                {
                    CheckBoxPanel.Background = new SolidColorBrush(Color.FromRgb(227, 227, 227));
                    //CheckBoxPanel.BackColor = Colors.WhiteTheme.MainColor;
                    //CheckBoxText.ForeColor = Colors.WhiteTheme.MainColor;
                    CheckBoxText.Foreground = new SolidColorBrush(Color.FromRgb(227, 227, 227));
                }
            }
        }

        private void CheckBox_Click(object sender, MouseEventArgs e)
        {
            
        }

        private void BCheckbox_Load(object sender, EventArgs e)
        {
            this.CheckBoxText.Text = Text;
            if (Checked)
            {
                //CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
                CheckBoxPanel.Background = new SolidColorBrush(Color.FromRgb(102, 153, 255));
            }
            else
            {
                //CheckBoxPanel.BackColor = SystemColors.ButtonHighlight;
                CheckBoxPanel.Background = new SolidColorBrush(SystemColors.WindowColor);
            }

            while (CheckBoxText.Width < MeasureString(CheckBoxText).Width)
            {
                CheckBoxText.FontSize -= 0.5f;
            }
        }

        private Size MeasureString(TextBlock tb)
        {
            var formattedText = new FormattedText(
                tb.Text,
                CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface(tb.FontFamily, tb.FontStyle, tb.FontWeight, tb.FontStretch),
                tb.FontSize,
                Brushes.Black);

            return new Size(formattedText.Width, formattedText.Height);
        }

        private void CheckBoxPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!Checked)
            {
                //CheckBoxPanel.BackColor = SystemColors.GradientActiveCaption;
                CheckBoxPanel.Background = new SolidColorBrush(SystemColors.GradientActiveCaptionColor);
            }
            else
            {
                //CheckBoxPanel.BackColor = Color.FromArgb(60, 123, 255);
                CheckBoxPanel.Background = new SolidColorBrush(Color.FromRgb(60, 123, 255));
            }
        }

        private void CheckBoxPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!Checked)
            {
                //CheckBoxPanel.BackColor = SystemColors.Window;
                CheckBoxPanel.Background = new SolidColorBrush(SystemColors.WindowColor);
            }
            else
            {
                //CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
                CheckBoxPanel.Background = new SolidColorBrush(Color.FromRgb(102, 153, 255));
            }
        }
        #endregion

        public void SetText(string _Text)
        {
            this.CheckBoxText.Text = _Text;
            Text = _Text;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Checked)
            {
                //CheckBoxPanel.BackColor = SystemColors.ButtonHighlight;
                CheckBoxPanel.Background = new SolidColorBrush(SystemColors.WindowColor);
            }
            else
            {
                //CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
                CheckBoxPanel.Background = new SolidColorBrush(Color.FromRgb(102, 153, 255));
            }
            Checked = !Checked;
            Checked_Changed?.Invoke(this, null);
        }
    }
}
