using AnimePlayerLibrary;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
namespace AnimePlayer
{
    public partial class OknoG : Form
    {
        FormMiniPlayer form2;
        string[] args = Environment.GetCommandLineArgs();
        public int server = 0;

        public Control controlAuxiliary;
        public WebContentControls.CtnPanel ctnPanelAuxiliary;

        public bool onOnline = true;
        PanelSearchFilters panelSearch;
        NewFlowLayoutPanel panelNews;

        public OknoG()  
        {
            InitializeComponent();
            AP_Lib aP_Lib = new AP_Lib((Form)this);
            form2 = new FormMiniPlayer(this);
            try
            {
                panelSearch = new PanelSearchFilters(flowLayoutPanelAll, flowLayoutPanelFinditem, AnimePlayer.Properties.Settings.Default.RoundingControl);
                panelSearch.Dock = DockStyle.None;
                panelAllitem.Controls.Add(panelSearch);
                panelSearch.Location = new Point(0, 110);
                panelSearch.Hide();
                labelLoadingDetails.Text = "Initialize";

                panelNews = new NewFlowLayoutPanel();
                panelNews.Dock = DockStyle.Fill;
                panelSTNewsMain.Controls.Add(panelNews);
                panelNews.Show();
                panelNews.ControlAdded += PanelNews_ControlAdded;
                panelSTNewsMain.Hide();
                Application.DoEvents();
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
                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\DatabaseOftitles"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\DatabaseOftitles");
                }
                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Temp"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Temp");
                }
            }
            catch (Exception)
            {

            }
            labelLoadingDetails.Text = "Download Files";
            backgroundWorkerGetSTNews.RunWorkerAsync();
            CreateBackupicon();
            if (AnimePlayer.Properties.Settings.Default.RoundingControl)
            {
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
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = panelMenu;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = buttonfinditemF;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = labelEnableFiltres;
                rc.CornerRadius = 15;
            }
        }

        private void PanelNews_ControlAdded(object sender, ControlEventArgs e)
        {
            panelNews.Show();
            panelSTNewsMain.Show();
            panelStartPage.Controls.SetChildIndex(panelSTNewsMain, 2);
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
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog()
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
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
            
        }

        private void buttonUseYTlink_Click(object sender, EventArgs e)
        {
        }

        private void otwórzZlinkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void buttonCloseWeb_Click(object sender, EventArgs e)
        {
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
                if (arg =="-offline")
                {
                    onOnline = false;
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

            /*
            if(panelNews.Controls.Count <= 0)
            {
                panelSTNewsMain.Hide();
            }
            */
            panelLoading.Hide();
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
            PageSettings pageSettings = new PageSettings(this);
            pageSettings.Dock = DockStyle.Fill;
            panel2.Controls.Add(pageSettings);
            pageSettings.Show();
            pageSettings.BringToFront();
        }

        private void buttonPlayer_Click(object sender, EventArgs e)
        {
            panelMenu.Hide();
            VideoPlayer videoPlayer = new VideoPlayer(panel2, true, this);
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
            catch (Exception ex)
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


        bool flags_findItem = false;

        private void buttonFindItem_Click(object sender, EventArgs e)
        {
            if(flags_findItem == false)
            {
                flowLayoutPanelFinditem.Controls.Clear();
                flowLayoutPanelFinditem.Enabled = false;
                findItems();
                flowLayoutPanelFinditem.Enabled = true;
            }
            else
            {
                Console.WriteLine("flags_findItem = true");
            }
        }



        public void findItemsF()
        {
            SetInfofilersLabel();
            string findText = textBoxFinditem.Text.ToLower().Replace("\n", "").Replace("\r", "").Replace("\t", "");
            if (textBoxFinditem.Text == null)
            {
                flowLayoutPanelFinditem.Hide();
                labelFindSatus.Hide();
                labelFindSatus.Text = "";
                flags_findItem = false;
                return;
            }
            int i = 0;
            bool add = true;
            flowLayoutPanelFinditem.Controls.Clear();
            labelFindSatus.Show();
            flowLayoutPanelAll.Hide();
            try
            {
                labelFindSatus.Text = "Szukanie";
                Application.DoEvents();
                List<string> unList = new List<string>();
                List<WebContent.Values> list = new List<WebContent.Values>();
                foreach (CheckBox box in panelSearch.panelAllS.Controls.OfType<CheckBox>())
                {
                    if (box.CheckState == CheckState.Unchecked)
                    {
                        unList.Add(box.Text);
                    }
                }
                labelFindSatus.Text += ".";
                Application.DoEvents();
                foreach (Control c in flowLayoutPanelAll.Controls)
                {
                    labelFindSatus.Text += ".";
                    Application.DoEvents();
                    add = true;
                    WebContentControls.CtnPanel cp = (WebContentControls.CtnPanel)c.Tag;
                    if (findText != null && findText != "")
                    {
                        if(!cp.values.name.ToLower().Contains(findText.ToLower()))
                        {
                            break;
                        }
                    }
                    foreach (string x in unList)
                    {
                        if (cp.values.titleInformation.Species.Contains(x))
                        {
                            add = false;
                        }
                    }

                    if(add)
                    {
                        flowLayoutPanelFinditem.Controls.Add(cp.Duplication());
                        i++;
                    }
                }
            }
            catch (Exception eex)
            {
                Console.WriteLine(eex.ToString());
            }
            textBoxFinditem.Text = findText;
            labelFindSatus.Text = "Znaleziono: " + i;
            Application.DoEvents();
            flowLayoutPanelFinditem.Show();
            flags_findItem = false;
        }


        public void findItems()
        {
            SetInfofilersLabel();
            flags_findItem = true;
            findItemsF();
            flags_findItem = false;
            return;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string findText = textBoxFinditem.Text.ToLower().Replace("\n", "").Replace("\r", "").Replace("\t", "");
            if (textBoxFinditem.Text == null)
            {
                flowLayoutPanelFinditem.Hide();
                labelFindSatus.Hide();
                labelFindSatus.Text = "";
                flags_findItem = false;
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
                        //test_start

;

                        //test_end
                        if (c.Tag != null)
                        {
                            WebContentControls.CtnPanel ctn = (WebContentControls.CtnPanel)c.Tag;
                            if (panelSearch.use == false)
                            {
                                if (ctn.values.name.ToLower().Contains(findText))
                                {
                                    flowLayoutPanelFinditem.Controls.Add(ctn.Duplication());
                                    i++;
                                }
                            }
                            else
                            {
                                bool noAdd = false;
                                if(panelSearch.use_Species && ctn.values.titleInformation.Species != null)
                                {
                                    //string tab;
                                    List<string> list = ctn.values.titleInformation.Species.ToList<string>(); //new List<string>();
                                    /*
                                    for(int j = 0; j<=ctn.values.titleInformation.Species.Length; j++)
                                    {
                                        tab = ctn.values.titleInformation.Species[j];
                                        
                                        for(int k = 0;j<= panelSearch.str_Species.Length; k++)
                                        {
                                            var matches = tab.//va.Where(p => p.Name == nameToExtract);
                                            
                                        }
                                        
                                        
                                        if (tab.ToLower() == "akcja")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "cyberpunk")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "dramat")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "ecchi")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "eksperymentalne")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "fantasy")
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "harem")
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "hentai")
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "historyczne" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "horror" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "komedia" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "kryminalne" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "magia" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "mecha" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "męski harem" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "muzyczne" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "nadprzyrodzone" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "obłęd" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "okruchy życia" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "parodia" )
                                        {
                                            list.Add(tab);
                                        }
                                        else if (tab.ToLower() == "przygodowe" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "psychologiczne" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "romans")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "sci-Fi" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "shoujo-ai" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "shounen-ai" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "space opera")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "sportowe" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "steampunk" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "szkolne" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "sztuki walki")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "tajemnica")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "thriller" )
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "wojskowe")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "yaoi")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                        else if (tab.ToLower() == "yuri")
                                        {
                                            list.Add(tab);
                                            break;
                                        }
                                    }
                                    */
                                    //Wykluczanie 

                                    try
                                    {
                                        /*
                                        foreach(string s in list)
                                        {
                                            foreach(CheckBox box in panelSearch.panelAllS.Controls.OfType<CheckBox>())
                                            {
                                                if(box.Checked == false)
                                                {
                                                    Console.WriteLine("string s in list:" + s);
                                                    Console.WriteLine("box:"+box.Text.ToLower());
                                                    if(s.ToLower() == box.Text.ToLower())
                                                    {
                                                        Console.WriteLine("if(s.ToLower() == box.Text.ToLower()) |> true");
                                                        noAdd = true;
                                                    }
                                                }
                                            }
                                        }
                                        */

                                        
                                        if (noAdd == false && panelSearch.use_Species && ctn.values.titleInformation.Species != null)
                                        {
                                            flowLayoutPanelFinditem.Controls.Add(ctn.Duplication());
                                            i++;
                                        }
                                    }
                                    catch (Exception exw)
                                    {
                                        Console.WriteLine(exw.ToString());
                                    }
                                }
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
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            stopWatch.Reset();
            Console.WriteLine("Loading time: " + elapsedTime);
            flags_findItem = false;
        }

        public List<Control> findItemsRetrunListControl(string findText)
        {
            findText = findText.ToLower().Replace("\n", "").Replace("\r", "").Replace("\t", "");
            List<Control> list = new List<Control>();
            if (findText == null)
            {
                return null;
            }
            try
            {
                foreach (Control c in flowLayoutPanelAll.Controls)
                {
                    try
                    {
                        Application.DoEvents();
                        if (c.Tag != null)
                        {
                            WebContentControls.CtnPanel ctn = (WebContentControls.CtnPanel)c.Tag;
                            if (ctn.values.name.ToLower().Contains(findText.ToLower()))
                            {
                                list.Add(ctn.Duplication());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                return list;
            }
            catch (Exception eex)
            {
                Console.WriteLine(eex.ToString());
                return null;
            }
        }
        
        public void findItems(string findText)
        {
            flags_findItem = true;
            Stopwatch stopWatch = new Stopwatch();
            findText = findText.ToLower().Replace("\n", "").Replace("\r", "").Replace("\t", "");
            if (findText == null)
            {
                flowLayoutPanelFinditem.Hide();
                labelFindSatus.Hide();
                labelFindSatus.Text = "";
                flags_findItem = false;
                return;
            }
            int i = 0;
            flowLayoutPanelFinditem.Controls.Clear();
            Application.DoEvents();
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

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            stopWatch.Reset();
            Console.WriteLine("Loading time: " + elapsedTime);
            flags_findItem = false;
        }

        private void buttonfinditemReset_Click(object sender, EventArgs e)
        {
            flowLayoutPanelFinditem.Controls.Clear();
            flowLayoutPanelFinditem.Hide();
            labelFindSatus.Text = "Szukanie";
            labelFindSatus.Hide();
            flowLayoutPanelAll.Show();
            textBoxFinditem.Text = "";
            GC.Collect();
        }


        private void buttonFinditemPageClose_Click(object sender, EventArgs e)
        {
            panelAllitem.Hide();
        }

        private void textBoxFinditem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        public void SetInfofilersLabel()
        {
            if (panelSearch.use_Species)
            {
                labelEnableFiltres.Show();
            }
            else
            {
                labelEnableFiltres.Hide();
            }
        }

        private void buttonfinditemF_Click(object sender, EventArgs e)
        {
            SetInfofilersLabel();
            if(panelSearch.Visible == true)
            {
                panelSearch.Hide();
                return;
            }
            if(panelSearch.Visible == false)
            {
                panelSearch.Show();
                panelSearch.BringToFront();
                return;
            }
        }

        private void backgroundWorkerGetSTNews_DoWork(object sender, DoWorkEventArgs e)
        {
            if(onOnline)
            {
                bool state = DownloadFileNews.DownloadWithGdrive();
                if(state == false)
                {
                    DownloadFileNews.DownloadWithOneDrive();
                }
                InterpreterFileNews.Start(panelNews, DownloadFileNews.GetPathListNews(), panel2);
            }
            else
            {
                InterpreterFileNews.Start(panelNews, DownloadFileNews.GetPathListNews(), panel2);
            }
            if(panelNews.Controls.Count > 0)
            {
                this.Invoke(new Action(() => panelNews.Show()));
            }
            return;
        }

        private void OknoG_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Directory.Delete(DefaultAppDir.Temp, true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
