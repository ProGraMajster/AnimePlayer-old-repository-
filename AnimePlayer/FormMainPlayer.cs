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
            ControlsNewMethods.RoundingControl rc = new ControlsNewMethods.RoundingControl();
            rc.TargetControl = buttonStartPageFinditem;
            rc.CornerRadius = 15;
            rc = new ControlsNewMethods.RoundingControl();
            rc.TargetControl = buttonMenuOpen;
            rc.CornerRadius = 15;
            rc = new ControlsNewMethods.RoundingControl();
            rc.TargetControl = textBoxStartPagefinditem;
            rc.CornerRadius = 15;

            rc = new ControlsNewMethods.RoundingControl();
            rc.TargetControl = textBoxFinditem;
            rc.CornerRadius = 15;
            rc = new ControlsNewMethods.RoundingControl();
            rc.TargetControl = buttonFindItem;
            rc.CornerRadius = 15;
            rc = new ControlsNewMethods.RoundingControl();
            rc.TargetControl = buttonfinditemReset;
            rc.CornerRadius = 15;
            rc = new ControlsNewMethods.RoundingControl();
            rc.TargetControl = buttonFinditemPageClose;
            rc.CornerRadius = 15;
            
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
        }

        bool stan_kl = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                if (panelMenu.Visible == false)
                {
                    panelMenu.Location = new Point(this.ClientSize.Width - panelMenu.Width, 0);
                    panelMenu.Size = new Size(panelMenu.Width, this.ClientSize.Height);
                    Application.DoEvents();
                    panelMenu.Show();
                    panelMenu.BringToFront();
                    return;
                }
                else if (panelMenu.Visible == true)
                {
                    panelMenu.Hide();
                    return;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

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
            panelMenu.Hide();
        }

        private void buttonMenuOpen_Click(object sender, EventArgs e)
        {
            panelMenu.Location = new Point(this.ClientSize.Width - panelMenu.Width, 0);
            panelMenu.Size = new Size(panelMenu.Width, this.ClientSize.Height);
            Application.DoEvents();
            panelMenu.Show();
            panelMenu.BringToFront();
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
        }

        private void buttonPlayer_Click(object sender, EventArgs e)
        {
            panelMenu.Hide();
            VideoPlayer videoPlayer = new VideoPlayer(panel2, true);
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

        private async void pictureBoxGithub_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    Process.Start("https://github.com/ProGraMajster/AnimePlayer");
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void pictureBoxSite_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    Process.Start("https://sites.google.com/view/twojeanimepl");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void buttonSite_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    Process.Start("https://sites.google.com/view/twojeanimepl");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        FormWindowState LastWindowState = FormWindowState.Normal;
        private void OknoG_Resize(object sender, EventArgs e)
        {
            if (labelLoading.Visible)
            {
                CenterControlInForm(labelLoading);
            }

            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;


                if (WindowState == FormWindowState.Maximized)
                {
                    if (panelMenu.Visible)
                    {
                        panelMenu.Location = new Point(-100000, -100000);
                        Application.DoEvents();
                        panelMenu.Hide();
                        panelMenu.Location = new Point(this.ClientSize.Width - panelMenu.Width, 0);
                        panelMenu.Size = new Size(panelMenu.Width, this.ClientSize.Height);
                        Application.DoEvents();
                        panelMenu.Show();
                    }
                    // Maximized!
                }
                if (WindowState == FormWindowState.Normal)
                {

                    // Restored!
                }
            }
        }

        private void OknoG_ResizeBegin(object sender, EventArgs e)
        {
            panelMenu.Location = new Point(-100000, -100000);
        }

        private void OknoG_ResizeEnd(object sender, EventArgs e)
        {
            if (labelLoading.Visible)
            {
                CenterControlInForm(labelLoading);
            }

            if (panelMenu.Visible)
            {
                panelMenu.Hide();
                Application.DoEvents();
                panelMenu.Location = new Point(this.ClientSize.Width - panelMenu.Width, 0);
                panelMenu.Size = new Size(panelMenu.Width, this.ClientSize.Height);
                Application.DoEvents();
                panelMenu.Show();
            }
        }

        private void flowLayoutPanelPolecane_ControlAdded(object sender, ControlEventArgs e)
        {
            taskAddToAllList(e);
        }


        public void flowLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            taskAddToAllList(e);
        }

        public Task taskAddToAllList(ControlEventArgs e)
        {
            try
            {
                WebContentControls.CtnPanel panel = (WebContentControls.CtnPanel)e.Control.Tag;
                flowLayoutPanelAll.Controls.Add(panel.Duplication());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        private void flowLayoutPanelAll_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void buttonFindItem_Click(object sender, EventArgs e)
        {
            findItems();
        }

        public void findItems()
        {
            string findText = textBoxFinditem.Text.ToLower().Replace("\n", "").Replace("\r", "").Replace("\t", "");
            if (textBoxFinditem.Text == null)
            {
                flowLayoutPanelFinditem.Hide();
                labelFindSatus.Hide();
                labelFindSatus.Text = "";
                return;
            }
            int i = 0;
            flowLayoutPanelFinditem.Controls.Clear();
            labelFindSatus.Show();
            flowLayoutPanelAll.Hide();
            try
            {
                labelFindSatus.Text = "Szukanie";
                Application.DoEvents();
                foreach (Control c in flowLayoutPanelAll.Controls)
                {
                    try
                    {
                        labelFindSatus.Text += ".";
                        Application.DoEvents();
                        if (c.Tag != null)
                        {
                            WebContentControls.CtnPanel ctn = (WebContentControls.CtnPanel)c.Tag;
                            if (ctn.values.name.ToLower().Contains(findText))
                            {
                                flowLayoutPanelFinditem.Controls.Add(ctn.Duplication());
                                i++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                textBoxFinditem.Text = findText;
                labelFindSatus.Text = "Znaleziono: " + i;
                flowLayoutPanelFinditem.Show();
            }
            catch (Exception eex)
            {
                Console.WriteLine(eex.ToString());
            }
        }
        
        public void findItems(string findText)
        {
            findText = findText.ToLower().Replace("\n", "").Replace("\r", "").Replace("\t", "");
            if (findText == null)
            {
                flowLayoutPanelFinditem.Hide();
                labelFindSatus.Hide();
                labelFindSatus.Text = "";
                return;
            }
            int i = 0;
            flowLayoutPanelFinditem.Controls.Clear();
            labelFindSatus.Show();
            flowLayoutPanelAll.Hide();
            try
            {
                labelFindSatus.Text = "Szukanie";
                Application.DoEvents();
                foreach (Control c in flowLayoutPanelAll.Controls)
                {
                    try
                    {
                        labelFindSatus.Text += ".";
                        Application.DoEvents();
                        if (c.Tag != null)
                        {
                            WebContentControls.CtnPanel ctn = (WebContentControls.CtnPanel)c.Tag;
                            if (ctn.values.name.ToLower().Contains(findText.ToLower()))
                            {
                                flowLayoutPanelFinditem.Controls.Add(ctn.Duplication());
                                i++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                labelFindSatus.Text = "Znaleziono: " + i;
                flowLayoutPanelFinditem.Show();
            }
            catch (Exception eex)
            {
                Console.WriteLine(eex.ToString());
            }
        }

        private void buttonfinditemReset_Click(object sender, EventArgs e)
        {
            flowLayoutPanelFinditem.Controls.Clear();
            flowLayoutPanelFinditem.Hide();
            labelFindSatus.Text = "Szukanie";
            labelFindSatus.Hide();
            flowLayoutPanelAll.Show();
            textBoxFinditem.Text = "";
        }

        private void buttonFinditemPageClose_Click(object sender, EventArgs e)
        {
            panelAllitem.Hide();
        }

        private void textBoxFinditem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                findItems();
            }
        }

        private void textBoxSPfinditem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panelAllitem.BringToFront();
                panelAllitem.Show();
                textBoxFinditem.Text = textBoxStartPagefinditem.Text;
                findItems(textBoxStartPagefinditem.Text);
                textBoxStartPagefinditem.Text = "";
            }
        }

        private void buttonStartPageFinditem_Click(object sender, EventArgs e)
        {
            panelAllitem.BringToFront();
            panelAllitem.Show();
            textBoxFinditem.Text = textBoxStartPagefinditem.Text;
            findItems(textBoxStartPagefinditem.Text);
            textBoxStartPagefinditem.Text = "";
        }

        private void buttonViewFindintems_Click(object sender, EventArgs e)
        {
            flowLayoutPanelFinditem.Controls.Clear();
            flowLayoutPanelFinditem.Hide();
            labelFindSatus.Text = "Szukanie";
            labelFindSatus.Hide();
            flowLayoutPanelAll.Show();
            panelAllitem.BringToFront();
            panelAllitem.Show();
        }

        private void buttonRestartApp_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }



        /*

private void buttonStart_Click(object sender, EventArgs e)
{
axWindowsMediaPlayer1.Ctlcontrols.play();
}
*/
    }
}
