using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimePlayer
{
    public partial class VideoPlayer : UserControl
    {
        public string videoLink;
        public string pathToFile;
        public double ShowSkipIntroTime = double.NaN;
        public double SkipIntro = double.NaN;
        Form form;
        public VideoPlayer(string vlink, Panel panel, string path, Form f, WebContent.Skip skip)
        {
            InitializeComponent();
            form = f;
            pathToFile = path;
            videoLink = vlink;
            panel.Controls.Add(this);
            this.Dock = DockStyle.Fill;
            this.BringToFront();
            this.Show();
            axwmp.URL = videoLink;
            label1.Text = "Status: Odtwarzanie";
            ShowSkipIntroTime = skip.time_showButton;
            SkipIntro = skip.time_skipIntro;
            axwmp.Ctlcontrols.pause();
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

        bool full = false;

        Size sizeform;

        private void button1_Click(object sender, EventArgs e)
        {
            if (full)
            {
                form.Size = sizeform;
                form.FormBorderStyle = FormBorderStyle.Sizable;
                full = false;
                timer.Start();
                panel1.Show();
                return;
            }
            else
            {
                sizeform = form.Size;
                full = true;
                timer.Stop();
                panel1.Hide();
                form.FormBorderStyle = FormBorderStyle.None;
                form.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                form.Location = new Point(0, 0);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axwmp.Ctlcontrols.play();
            label1.Text = "Status: Odtwarzanie";
            timer.Start();
            timerShowSkipButton.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axwmp.Ctlcontrols.pause();
            label1.Text = "Status: Wstrzymano";
            timer.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(openFileDialog.FileName))
                    {
                        axwmp.URL = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void timerShowSkipButton_Tick(object sender, EventArgs e)
        {
            if (axwmp.Ctlcontrols.currentPosition == ShowSkipIntroTime)
            {
                buttonSkip.Show();
                timerHidebuttonSkip.Start();
                timerShowSkipButton.Stop();
            }
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            axwmp.Ctlcontrols.currentPosition = SkipIntro;
            buttonSkip.Hide();
        }

        private void timerHidebuttonSkip_Tick(object sender, EventArgs e)
        {
            buttonSkip.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "PlayerType_1")
            {
                axwmp.uiMode = "full";
            }
            else
            {
                axwmp.uiMode = "none";
            }
        }

        private void VideoPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.Y <= 30)
            {
                panel1.Show();
            }
            else
            {
                panel1.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
