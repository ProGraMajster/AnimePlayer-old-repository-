using System;
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

        }
    }
}