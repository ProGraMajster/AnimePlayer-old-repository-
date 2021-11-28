using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimePlayerLibrary
{
    public partial class ItemsGroup : UserControl
    {
        string groupTitle;
        Form formMain;
        Panel panelMain;
        public ItemsGroup(Form form, string title)
        {
            InitializeComponent();
            formMain = form;
            groupTitle = title;
            try
            {
                panelMain = (Panel)form.Controls.Find("panelStartPage", true)[0];
            }
            catch(Exception ex)
            {
                FileLog.Write(ex.ToString());
            }
        }
    }
}
