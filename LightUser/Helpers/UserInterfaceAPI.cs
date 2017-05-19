using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Drawing;

namespace LightUser.Helpers
{
    class UserInterfaceAPI
    {
        public static void InitFonts(Control control)
        {
            control.FontFamily = new FontFamily("Century Gothic");
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(control); i++)
            {
                InitFonts((Control)VisualTreeHelper.GetChild(control, i));
            }
        }
    }
}
