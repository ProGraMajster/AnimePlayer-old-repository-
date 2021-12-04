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
    public partial class FormDebug : Form
    {
        public FormDebug()
        {
            InitializeComponent();
        }

        public FormDebug(ValuesDebug vd)
        {
            InitializeComponent();
            RtbNewlinie(vd.ToString());
            RtbNewlinie("path: " + vd.path);
            RtbNewlinie("name: "+ vd.name);
            RtbNewlinie("iconLink: "+vd.iconLink);
            RtbNewlinie("iconPath: "+vd.iconPath);
            RtbNewlinie("siteLink: "+ vd.siteLink);
            RtbNewlinie("contentId: "+vd.contentId);
            RtbNewlinie("contentId2: "+ vd.contentId2);
            RtbNewlinie("pathPage: "+vd.pathPage);
            RtbNewlinie("groupName: "+vd.groupName);
        }

        void RtbNewlinie(string text)
        {
            richTextBox.Text += Environment.NewLine+text;
        }
    }
}
