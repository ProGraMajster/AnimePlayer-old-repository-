using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AnimePlayerLibrary
{
    public static class ThemeChanger
    {
        public static void SetDefaultBackgroundColorFLP(Panel panel)
        {
            if(panel == null)
            {
                return;
            }
            panel.BackColor = Color.FromArgb(20, 20, 20);
        }

        public static void InterpretingFile(Form form)
        {
            try
            {
                if(form == null)
                {
                    return ;
                }
                Panel panelStartPage = (Panel)form.Controls.Find("panelStartPage", true)[0];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
