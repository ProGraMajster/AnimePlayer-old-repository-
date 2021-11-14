using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimePlayer
{
    public partial class VideoPlayer : UserControl
    {
        public string videoLink;
        public VideoPlayer(string vlink, Panel panel)
        {
            InitializeComponent();
            videoLink = vlink;
            panel.Controls.Add(this);
            this.Dock = DockStyle.Fill;
            this.BringToFront();
            this.Show();
            axwmp.URL = videoLink;
        }

        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axwmp.fullScreen = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axwmp.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axwmp.Ctlcontrols.pause();
        }
    }
}
