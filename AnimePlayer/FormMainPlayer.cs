using AxWMPLib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Text;
using AnimePlayer;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Shell;

namespace AnimePlayer
{
    public partial class OknoG : Form
    {
        FormMiniPlayer form2;
        string[] args = Environment.GetCommandLineArgs();

        public bool onOnline = true;
        public OknoG()
        {
            InitializeComponent();
            form2 = new FormMiniPlayer(this);
            try
            {

                if (!Directory.Exists("C:\\ContentLibrarys"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys");
                }
                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles");
                }
                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp");
                }

                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon");
                }

                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup");
                }

                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Page"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Page");
                }
                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video");
                }
            }
            catch (Exception)
            {

            }
            CreateBackupicon();
        }

        Task CreateBackupicon()
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon");

                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    File.Copy(fileInfo.FullName, "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup\\" + fileInfo.Name, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public Bitmap shellThumb;
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Wszystkie pliki (*.*)|*.*|Pliki mp4 (*.mp4)|*.mp4"
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //axWindowsMediaPlayer1.URL = openFileDialog.FileName;
                ShellFile shellFile = ShellFile.FromFilePath(openFileDialog.FileName);
                shellThumb = shellFile.Thumbnail.ExtraLargeBitmap;
            }
        }

        private void zamknijProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            form2.Hide();
            this.Hide();
            notifyIcon1.Visible = false;
            Application.DoEvents();
            Application.Exit();
        }

        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        bool stan_kl = false;
        bool fullwindow = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11 && fullwindow == false && stan_kl == false)
            {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                fullwindow = true;
                stan_kl = true;
            }

            if (e.KeyCode == Keys.F11 && fullwindow == true && stan_kl == false)
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                fullwindow = false;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11 && stan_kl == true)
            {
                stan_kl = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            form2.Show();
        }


        private void buttonYTlinkClose_Click(object sender, EventArgs e)
        {
            panelYTlink.Visible = false;
            textBoxYTlink.Text = "";
        }

        private void buttonUseYTlink_Click(object sender, EventArgs e)
        {
            panelYTlink.Visible = false;
        }

        private void otwórzZlinkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelYTlink.Visible = true;
            panelYTlink.BringToFront();
        }

        private void buttonCloseWeb_Click(object sender, EventArgs e)
        {
            panelWeb.Visible = false;
            panelMainPlayer.Visible = true;
        }

        private void OknoG_Load(object sender, EventArgs e)
        {
            bool local = false;
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg == "-local")
                {
                    local = true;
                }
            }


            if (local == false)
            {
                panelLoading.BringToFront();
                CenterControlInForm(labelLoading);
                panelLoading.Show();
                this.Show();
                Application.DoEvents();
                WebContent.Initialize(this);
            }
            else
            {
                panelLoading.BringToFront();
                CenterControlInForm(labelLoading);
                panelLoading.Show();
                this.Show();
                Interpreter interpreter = new Interpreter(this);
                interpreter.Local();
            }
        }

        public void CenterControlInForm(Control control)
        {
            try
            {
                control.Left = (this.ClientSize.Width - control.Width) / 2;
                control.Top = (this.ClientSize.Height - control.Height) / 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine);
                //MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            RoundedPanel panel = (RoundedPanel)sender;
            panel.Refresh();
        }

        private void buttonMenuClose_Click(object sender, EventArgs e)
        {
            panelMenu.Dock = DockStyle.None;
            panelMenu.Hide();
        }

        private void buttonMenuOpen_Click(object sender, EventArgs e)
        {
            panelMenu.Dock = DockStyle.Right;
            panelMenu.Show();
        }

        private void OknoG_ResizeEnd(object sender, EventArgs e)
        {
            if (labelLoading.Visible)
            {
                CenterControlInForm(labelLoading);
            }
        }

        private void labelLoading_VisibleChanged(object sender, EventArgs e)
        {
            CenterControlInForm(labelLoading);
        }

        private void panelLoading_VisibleChanged(object sender, EventArgs e)
        {
            CenterControlInForm(labelLoading);
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            panelMenu.Hide();
            panelSettings.BringToFront();
            panelSettings.Show();
        }

        private void buttonPlayer_Click(object sender, EventArgs e)
        {
            panelMenu.Hide();
            panelPlayer.BringToFront();
            panelPlayer.Show();
        }

        private void buttonExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int timerShow = 20;
        int timer_i = 0;

        public void ShowErrorCode(string text, int time)
        {
            timer_i = 0;
            labelError.Text = text;
            timerShow = time;
            timerAnimationError.Start();
        }

        private void timerAnimationError_Tick(object sender, EventArgs e)
        {

            timer_i++;
            panelNotifiError.Show();
            panelNotifiError.BringToFront();
            panelNotifiError.Location = new Point(this.ClientSize.Width - panelNotifiError.Width,
                this.ClientSize.Height - panelNotifiError.Height);
            if (timer_i >= timerShow)
            {
                timer_i = 0;
                timerAnimationError.Stop();
                panelNotifiError.Hide();
            }
        }
        /*

private void buttonStart_Click(object sender, EventArgs e)
{
axWindowsMediaPlayer1.Ctlcontrols.play();
}
*/
    }
}
