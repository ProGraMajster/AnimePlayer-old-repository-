using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimePlayer
{
    public partial class PageSettings : UserControl
    {
        public PageSettings()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            checkBoxRoundedEdges.Checked = AnimePlayer.Properties.Settings.Default.RoundingControl;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void checkBoxRoundedEdges_CheckedChanged(object sender, EventArgs e)
        {
            //there is an error in this event
            Action action = () =>
            {
                AnimePlayer.Properties.Settings.Default.RoundingControl = checkBoxRoundedEdges.Checked;
            };

            if (checkBoxRoundedEdges.Checked)
            {
                checkBoxRoundedEdges.Checked = false;
                action();
                return;
            }
            else
            {
                checkBoxRoundedEdges.Checked = true;
                action();
                return;
            }
        }
    }
}