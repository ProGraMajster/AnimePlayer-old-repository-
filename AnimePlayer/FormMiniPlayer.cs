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
    public partial class FormMiniPlayer : Form
    {
        private OknoG formaa1;

        private bool isPlaying()
        {
            return false;
           // return formaa1.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsReady || formaa1.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying;
        }

        public FormMiniPlayer(OknoG forma)
        {
            InitializeComponent();
            formaa1 = forma;
        }

        private void buttonControlP_Click(object sender, EventArgs e)
        {
            /*
            if (formaa1.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                buttonControlP.Text = "Pause";
                formaa1.axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else if (formaa1.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                formaa1.axWindowsMediaPlayer1.Ctlcontrols.play();
                buttonControlP.Text = "Reasume";
            }
            */
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(860, 555);
            timerKontrol.Start();
        }

        private void timerKontrol_Tick(object sender, EventArgs e)
        {
            try
            {
                /*
                if (formaa1.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    buttonControlP.Text = "Pause";
                }
                else
                {
                    buttonControlP.Text = "Reasume";
                }

                if (formaa1.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    labelNameFile.Text = formaa1.axWindowsMediaPlayer1.currentMedia.name.ToString();
                    labelCzas.Text = ("Czas: " + formaa1.axWindowsMediaPlayer1.Ctlcontrols.currentPositionString + " - " + formaa1.axWindowsMediaPlayer1.currentMedia.durationString);
                    if (formaa1.shellThumb != null)
                    {
                        pictureBoxFile.Image = formaa1.shellThumb;
                    }
                    else
                    {
                        Icon ico = Icon.ExtractAssociatedIcon(formaa1.axWindowsMediaPlayer1.currentMedia.sourceURL.ToString());
                        pictureBoxFile.Image = ico.ToBitmap();
                    }
                }
                */

            }
            catch (Exception)
            {

            }
        }

        private void buttonDoprzodu_Click(object sender, EventArgs e)
        {
            if (isPlaying())
            {
                //formaa1.axWindowsMediaPlayer1.Ctlcontrols.currentPosition += 5;
            }
        }

        private void buttonDotylu_Click(object sender, EventArgs e)
        {
            if (isPlaying())
            {
                //formaa1.axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 5;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
