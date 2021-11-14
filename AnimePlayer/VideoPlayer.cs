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
        public VideoPlayer(Panel panel, bool local)
        {
            InitializeComponent();
            panel.Controls.Add(this);
            this.Dock = DockStyle.Fill;
            this.BringToFront();
            this.Show();
            button4.Visible = local;
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(System.IO.File.Exists(openFileDialog.FileName))
                    {
                        axwmp.URL = openFileDialog.FileName;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
