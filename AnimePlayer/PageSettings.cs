using AnimePlayerLibrary;
using System;
using System.Windows.Forms;

namespace AnimePlayer
{
    public partial class PageSettings : UserControl
    {
        public PageSettings(OknoG okno)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            checkBoxRoundedEdges.Checked = AnimePlayer.Properties.Settings.Default.RoundingControl;
            labelServer.Text = "Serwer danych nr.: " + okno.server;
            if (AnimePlayer.Properties.Settings.Default.RoundingControl)
            {
                ControlsNewMethods.RoundingControl rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = buttonClose;
                rc.CornerRadius = 15;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void checkBoxRoundedEdges_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AnimePlayer.Properties.Settings.Default.RoundingControl = checkBoxRoundedEdges.Checked;
                AnimePlayer.Properties.Settings.Default.Save();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}