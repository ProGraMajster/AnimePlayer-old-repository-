using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnimePlayerLibrary;

namespace AnimePlayer
{
    public static class WebContent
    {
        public class Skip
        {
            public double time_showButton { get; set; }
            public double time_skipIntro { get; set; }
        }

        public class Values
        {
            public Values(string pathToFile)
            {
                path = pathToFile;
            }
            public Values()
            {

            }

            public string path { get; set; }
            public string name { get; set; }
            public string iconLink { get; set; }
            public string iconPath { get; set; }
            public string siteLink { get; set; }
            public string contentId { get; set; }
            public string contentId2 { get; set; }
            public string pathPage { get; set; }
            public string groupName { get; set; }
        }

        public static void Initialize(OknoG oknoG)
        {
            oknoG.labelLoadingDetails.Text = "Initialize";
            oknoG.panelLoading.Show();
            Application.DoEvents();
            oknoG.labelLoadingDetails.Text = "DonloadMainFile";
            Application.DoEvents();
            if (downloadMainFile(oknoG) == false)
            {
                //MessageBox.Show("Wystąpił błąd podczas pobierania zawartości!", "Wstąpił błąd", MessageBoxButtons.OK);
                oknoG.labelLoadingDetails.Text = "DownloadMainFile > an error occured";
                oknoG.labelSatusWorkingApp.Text = "Status działania: Ograniczony";
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(oknoG.labelSatusWorkingApp, "Ograniczony dostęp do serwera");
                oknoG.ShowErrorCode("Error code: DF01", 500);
                oknoG.timerAnimationError.Start();
                Console.WriteLine("--------- Local ----------");
                oknoG.labelLoading.Text += ".";
                oknoG.labelLoadingDetails.Text = "Interpreter > Local";
                Application.DoEvents();
                Interpreter interpreter = new Interpreter(oknoG);
                interpreter.Local();
                oknoG.onOnline = false;
                oknoG.labelLoading.Text += ".";
                Application.DoEvents();
            }
            else
            {
                oknoG.labelLoadingDetails.Text = "DownloadMainFile > successfully downloaded >> openMainFile";
                oknoG.labelLoading.Text += ".";
                Application.DoEvents();
                openMainFile(oknoG);
                oknoG.labelLoading.Text += ".";
                Application.DoEvents();
                oknoG.onOnline = true;
                oknoG.labelSatusWorkingApp.Text = "Status działania: Prawidłowy";
            }

            oknoG.panelLoading.Hide();
            oknoG.labelLoading.Text = "Ładowanie...";
            Application.DoEvents();
        }
        public static void openMainFile(OknoG oknoG)
        {
            oknoG.labelLoadingDetails.Text = "openMainFile > File.Exists";
            Application.DoEvents();
            if (File.Exists("main.txt"))
            {
                oknoG.labelLoadingDetails.Text = "openMainFile > File.ReadAllLines";
                Application.DoEvents();
                string[] line = File.ReadAllLines("main.txt");
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != null)
                    {
                        oknoG.labelLoadingDetails.Text = "openMainFile > downloadFile: "+i +"/"+ (line.Length-1);
                        Application.DoEvents();
                        if(oknoG.server == 0)
                        {
                            downloadFile(line[i]);
                        }
                        else if(oknoG.server == 1)
                        {
                            AnimePlayerLibrary.Download.OneDrive.downloadFile(line[i]);
                        }
                    }
                }


                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != null)
                    {
                        oknoG.labelLoadingDetails.Text = "openMainFile > Interpreter > file: " + i + "/" + (line.Length - 1);
                        Application.DoEvents();
                        Interpreter interpreter = new Interpreter(oknoG);
                        if(oknoG.server == 0)
                        {
                            interpreter.Start("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\" + line[i] + ".txt");
                        }
                        else if(oknoG.server == 1)
                        {
                            interpreter.Start("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\" + Download.OneDrive.onedriveUri(line[i]) + ".txt");
                        }
                    }
                }
            }
        }

        public static bool downloadMainFile(OknoG oknoG)
        {
            try
            {
                try
                {
                    foreach (string a in Environment.GetCommandLineArgs())
                    {
                        if (a == "-local")
                        {
                            return false;
                        }
                        else if(a == "-server_0")
                        {
                            oknoG.server = 0;
                        }
                        else if(a == "-server_1")
                        {
                            oknoG.server = 1;
                        }
                    }
                    Console.WriteLine("downloadMainFile");
                    if (oknoG.server == 0)
                    {
                        Console.WriteLine("server: 0");
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(dUri(AnimePlayer.Properties.Settings.Default.idMain), "main.txt");
                        webClient.Dispose();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("server: 1");
                        return AnimePlayerLibrary.Download.OneDrive.MainFile();
                    }
                }
                catch(Exception ex0)
                {
                    Console.WriteLine(ex0.ToString());
                    oknoG.server = 1;
                    return AnimePlayerLibrary.Download.OneDrive.MainFile();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static void downloadFile(string id)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(dUri(id), "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\" + id + ".txt");
                webClient.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ERROR}downloadPage > \n" + id);
                Console.WriteLine(ex.ToString() + Environment.NewLine);
            }
        }

        public static void downloadFile(string id, string path)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(dUri(id), path);
                webClient.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ERROR}downloadPage > \n" + id + "\n" + path);
                Console.WriteLine(ex.ToString() + Environment.NewLine);
            }
        }

        public static string downloadPage(string id, string filename)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(dUri(id), "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Page\\" + filename + ".txt");
                webClient.Dispose();
                return "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Page\\" + filename + ".txt";
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ERROR}downloadPage > \n" + id + "\n" + filename);
                Console.WriteLine(ex.ToString() + Environment.NewLine);
                return null;
            }
        }


        public static string downloadIcon(string link, string filename)
        {
            try
            {

                WebClient webClient = new WebClient();
                webClient.DownloadFile(link, "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon\\" + filename.Replace(":", " ") + ".png");
                webClient.Dispose();
                return "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon\\" + filename.Replace(":", " ") + ".png";
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------- downloadIcon ------");
                Console.WriteLine("filename: " + filename);
                Console.WriteLine("{ERROR}downloadPage > \n" + link + "\n" + filename);
                Console.WriteLine(ex.ToString() + Environment.NewLine);
                return null;
            }
        }

        public static string downloadVideoContent(string link, string filename)
        {
            try
            {
                if (!Directory.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video"))
                {
                    Directory.CreateDirectory("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video");
                }
                WebClient webClient = new WebClient();
                webClient.DownloadFile(link, "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video\\" + filename + "_list_ep.txt");
                webClient.Dispose();
                return "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video\\" + filename + "_list_ep.txt";
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ERROR}downloadPage > \n" + link + "\n" + filename);
                Console.WriteLine(ex.ToString() + Environment.NewLine);
                return null;
            }
        }

        public static string dUri(string id)
        {
            id = "https://drive.google.com/uc?export=download&id=" + id;
            return id;
        }
    }

    public static class WebContentControls
    {

        public class CtnPanel
        {
            public WebContent.Values values;
            OknoG oknoG;

            public Panel panelItem;
            public PictureBox pictureBoxItem;
            public Button buttonItem;

            public CtnPanel(WebContent.Values va, OknoG okno)
            {
                values = va;
                oknoG = okno;

                // 
                // pictureBoxItem
                // 
                oknoG.labelLoadingDetails.Text = ">> Create CtnPanel file:" +va.path +" > create PictureBox";
                Application.DoEvents();
                pictureBoxItem = new PictureBox();
                this.pictureBoxItem.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pictureBoxItem.Image = global::AnimePlayer.Properties.Resource.NoImage;
                pictureBoxItem.ErrorImage = AnimePlayer.Properties.Resource.NoImage;
                pictureBoxItem.InitialImage = AnimePlayer.Properties.Resource.NoImage;
                this.pictureBoxItem.Location = new System.Drawing.Point(0, 0);
                this.pictureBoxItem.Name = "pictureBoxItem";
                this.pictureBoxItem.Size = new System.Drawing.Size(160, 199);
                this.pictureBoxItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBoxItem.BackgroundImageLayout = ImageLayout.Zoom;
                this.pictureBoxItem.TabIndex = 0;
                this.pictureBoxItem.TabStop = false;
                // 
                // buttonItem
                // 
                oknoG.labelLoadingDetails.Text = ">> Create CtnPanel file:" + va.path + "> create Button";
                Application.DoEvents();
                buttonItem = new Button();
                this.buttonItem.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.buttonItem.Location = new System.Drawing.Point(0, 199);
                this.buttonItem.Name = "buttonItem";
                buttonItem.ForeColor = Color.White;
                buttonItem.AutoSize = true;
                buttonItem.Font = new Font(buttonItem.Font.FontFamily, 9f);
                buttonItem.FlatStyle = FlatStyle.Flat;
                buttonItem.FlatAppearance.BorderSize = 0;
                buttonItem.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
                this.buttonItem.Size = new System.Drawing.Size(177, 42);
                this.buttonItem.TabIndex = 1;
                this.buttonItem.Text = "Name";
                buttonItem.AutoEllipsis = true;
                this.buttonItem.UseVisualStyleBackColor = true;

                // 
                // panelItem
                // 
                oknoG.labelLoadingDetails.Text = ">> Create CtnPanel file:" + va.path + "> create Panel";
                Application.DoEvents();
                panelItem = new Panel();
                panelItem.Tag = this;
                this.panelItem.Controls.Add(pictureBoxItem);
                this.panelItem.Controls.Add(buttonItem);
                this.panelItem.Location = new System.Drawing.Point(13, 5);
                this.panelItem.Name = "panelItem";
                this.panelItem.Size = new System.Drawing.Size(160, 240);
                panelItem.BackColor = Color.FromArgb(30, 30, 30);
                this.panelItem.TabIndex = 0;
                if (va.groupName.EndsWith("Polecane"))
                {
                    oknoG.labelLoadingDetails.Text = ">> Create CtnPanel file:" + va.path + "> Add to group";
                    Application.DoEvents();
                    okno.flowLayoutPanelPolecane.Controls.Add(panelItem);
                    Application.DoEvents();
                }

                oknoG.labelLoadingDetails.Text = ">> Create CtnPanel file:" + va.path + "> Set name";
                Application.DoEvents();
                SetName();
                oknoG.labelLoadingDetails.Text = ">> Create CtnPanel file:" + va.path + "> Set image";
                Application.DoEvents();
                SetImage();
                buttonItem.Click += ButtonItem_Click;
                pictureBoxItem.Click += ButtonItem_Click;
                if (AnimePlayer.Properties.Settings.Default.RoundingControl)
                {
                    oknoG.labelLoadingDetails.Text = ">> Create CtnPanel > RoundingControl";
                    ControlsNewMethods.RoundingControl rc = new ControlsNewMethods.RoundingControl();
                    rc.TargetControl = buttonItem;
                    rc.CornerRadius = 15;
                    rc = new ControlsNewMethods.RoundingControl();
                    rc.TargetControl = panelItem;
                    rc.CornerRadius = 15;
                }
                oknoG.labelLoadingDetails.Text = ">> Create CtnPanel > "+va.name+ "> Created";
            }

            public CtnPanel()
            {
            }

            private void ButtonItem_Click(object sender, EventArgs e)
            {
                oknoG.labelLoadingDetails.Text = "Click >" + values.name;
                Application.DoEvents();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                oknoG.panelLoading.BringToFront();
                oknoG.panelLoading.Show();
                Application.DoEvents();
                if (values.pathPage != null)
                {
                    SetPage(values.pathPage);
                }
                else
                {
                    if (oknoG.onOnline == true)
                    {
                        oknoG.labelLoadingDetails.Text = "Click >" + values.name +" > downloadPage";
                        Application.DoEvents();
                        if (oknoG.server == 0)
                        {
                            values.pathPage = WebContent.downloadPage(values.contentId, values.name + "_page");
                        }
                        else if(oknoG.server == 1 )
                        {
                            values.pathPage = Download.OneDrive.downloadPage(values.contentId2, values.name + "_page");
                        }

                        if (values.pathPage != null)
                        {
                            SetPage(values.pathPage);
                        }
                        else
                        {
                            oknoG.labelLoadingDetails.Text = "Click >" + values.name + " > donloadPage > Error";
                            Application.DoEvents();
                            MessageBox.Show("Nie udało się załadować strony!", "Błąd",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        oknoG.labelLoadingDetails.Text = "Click >" + values.name + " > load local";
                        Application.DoEvents();
                        SetPage("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Page\\" + values.name + "_page.txt");
                    }
                }
                oknoG.panelLoading.Hide();
                Application.DoEvents();
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                stopWatch.Reset();
                Console.WriteLine("{CtnPanel} Loading page time: " + elapsedTime);
            }

            public void SetName()
            {
                buttonItem.Text = values.name;
            }

            public void SetImage()
            {
                try
                {
                    SetImage2(pictureBoxItem);
                    /*
                    pictureBoxItem.Tag = values.iconPath;
                    pictureBoxItem.ImageLocation = values.iconPath;
                    pictureBoxItem.LoadAsync(values.iconPath);
                    */
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString() + Environment.NewLine);
                }
            }
            
            public void SetImage2(PictureBox box)
            {
                string nam = values.name.Replace(":","");
                Interpreter interpreter = new Interpreter(oknoG);
                try
                {
                    if(interpreter.FindFileNameInDirIcon(nam + "_icon.png"))
                    {
                        box.Tag = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon\\" + nam + "_icon.png";
                        //box.ImageLocation = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon\\" + nam + "_icon.png";
                        box.LoadAsync("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon\\" + nam + "_icon.png");
                    }
                    else
                    {
                        box.Tag = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup\\" + nam + "_icon.png";
                        //box.ImageLocation = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup\\" + nam + "_icon.png";
                        box.LoadAsync("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup\\" + nam + "_icon.png");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString() + Environment.NewLine);
                    try
                    {   
                        box.Tag = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup\\" + nam + "_icon.png";
                       // box.ImageLocation = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup\\" + nam + "_icon.png";
                        box.LoadAsync("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup\\" + nam + "_icon.png");
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine(ex2.ToString() + Environment.NewLine);
                        box.Image = AnimePlayer.Properties.Resource.NoImage;
                    }
                }
            }

            public Panel Duplication()
            {
                // 
                // picture
                // 
                PictureBox picture = new PictureBox();
                picture.Dock = System.Windows.Forms.DockStyle.Fill;
                picture.Image = global::AnimePlayer.Properties.Resource.NoImage;
                picture.ErrorImage = AnimePlayer.Properties.Resource.NoImage;
                picture.InitialImage = AnimePlayer.Properties.Resource.NoImage;
                picture.Location = new System.Drawing.Point(0, 0);
                picture.Name = "pictureBoxItem";
                picture.Size = new System.Drawing.Size(160, 199);
                picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                picture.BackgroundImageLayout = ImageLayout.Zoom;
                picture.TabIndex = 0;
                // 
                // button
                // 
                Button button = new Button();
                button.Dock = System.Windows.Forms.DockStyle.Bottom;
                button.Location = new System.Drawing.Point(0, 199);
                button.Name = "buttonItem";
                button.ForeColor = Color.White;
                button.AutoSize = true;
                button.Font = new Font(button.Font.FontFamily, 9f);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
                button.Size = new System.Drawing.Size(177, 42);
                button.TabIndex = 1;
                button.Text = "Name";
                button.AutoEllipsis = true;
                button.UseVisualStyleBackColor = true;

                // 
                // panel
                // 
                Panel panel = new Panel();
                panel.Tag = this;
                panel.Controls.Add(picture);
                panel.Controls.Add(button);
                panel.Location = new System.Drawing.Point(13, 5);
                panel.Name = "panelItem";
                panel.Size = new System.Drawing.Size(160, 240);
                panel.BackColor = Color.FromArgb(30, 30, 30);
                button.Click += ButtonItem_Click;
                picture.Click += ButtonItem_Click;
                try
                {
                    button.Text = values.name;
                    SetImage2(picture);
                    /*
                    picture.ImageLocation = values.iconPath;
                    picture.LoadAsync(values.iconPath);
                    */
                    if (AnimePlayer.Properties.Settings.Default.RoundingControl)
                    {
                        ControlsNewMethods.RoundingControl rc = new ControlsNewMethods.RoundingControl();
                        rc.TargetControl = button;
                        rc.CornerRadius = 15;
                        rc = new ControlsNewMethods.RoundingControl();
                        rc.TargetControl = panel;
                        rc.CornerRadius = 15;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return panel;
            }

            public void SetPage(string path)
            {
                oknoG.labelLoadingDetails.Text = "Load page: " + values.name + " [0%]";
                Application.DoEvents();
                if (!File.Exists(path))
                {
                    oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> file not found";
                    Application.DoEvents();
                    MessageBox.Show("Wystąpił błąd podczas ładowania zawartości!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oknoG.labelLoadingDetails.Text = "Load page: " + values.name + " [1%]";
                Application.DoEvents();
                PageItem pageItem1 = new PageItem(values, oknoG);
                oknoG.labelLoadingDetails.Text = "Load page: " + values.name + " [10%]";
                Application.DoEvents();
                oknoG.panel2.Controls.Add(pageItem1);
                pageItem1.Dock = DockStyle.Fill;
                pageItem1.BringToFront();
                try
                {
                    pageItem1.pictureBoxIcon.LoadAsync(values.iconPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString() + Environment.NewLine);
                }

                oknoG.labelLoadingDetails.Text = "Load page: " + values.name + " [15%]";
                Application.DoEvents();

                string[] content = File.ReadAllText(path).Split(';');
                int limits = 0;
                for (int i = 0; i < content.Length; i++)
                {
                    limits = i;
                    content[i] = content[i].Replace("\n", "").Replace("\r", "").Replace("\t", "");
                }
                oknoG.labelLoadingDetails.Text = "Load page: " + values.name + " [20%]";
                Application.DoEvents();
                try
                {
                    bool end = false;
                    int position = 0;
                    while (end != true)
                    {
                        if (position == limits)
                        {
                            end = true;
                        }

                        if (content[position] == "Content")
                        {
                            pageItem1.labelTitle.Text = values.name;
                        }
                        else if (content[position] == "description")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > description";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelDes.Text = content[position];
                        }
                        else if (content[position] == "OtherName")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > OtherName";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelotherTitle.Text = content[position];
                        }
                        else if (content[position] == "OtherTags")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > OtherTags";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelOtherTags.Text = content[position];
                        }
                        else if (content[position] == "Archetype")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > Archetype";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelArchetype.Text = content[position];
                        }
                        else if (content[position] == "Species")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > Species";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelSpecies.Text = content[position];
                        }
                        else if (content[position] == "typesOfCharacters")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > typesOfCharacters";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelTypesOfCharacters.Text = content[position];
                        }
                        else if (content[position] == "TargetGroups")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > TargetGroups";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelTargetGroups.Text = content[position];
                        }
                        else if (content[position] == "PlaceAndTime")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > PlaceAndTime";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelPlaceAndTime.Text = content[position];
                        }
                        else if (content[position] == "Type")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > Type";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelType.Text = content[position];
                        }
                        else if (content[position] == "Status")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > Status";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelStatus.Text = content[position];
                        }
                        else if (content[position] == "DateOfIssue")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > DateOfIssue";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelDateS.Text = content[position];
                        }
                        else if (content[position] == "EndOfIssue")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > EndOfIssue";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelDateE.Text = content[position];
                        }
                        else if (content[position] == "NumberOfEpisodes")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > NumberOfEpisodes";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelNE.Text = content[position];
                        }
                        else if (content[position] == "Studio")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > Studio";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelStudio.Text = content[position];
                        }
                        else if (content[position] == "EpisodeLength")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > EpisodeLength";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelLE.Text = content[position];
                        }
                        else if (content[position] == "MPAA")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > MPAA";
                            Application.DoEvents();
                            position++;
                            pageItem1.labelMPAA.Text = content[position];
                        }
                        else if (content[position] == "EpisodeList")
                        {
                            oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > episode list";
                            Application.DoEvents();
                            position++;
                            if (oknoG.onOnline)
                            {
                                if(oknoG.server == 0)
                                {
                                    string zm = WebContent.downloadVideoContent(WebContent.dUri(content[position]), values.name);
                                    GetListTypeEp(pageItem1, zm);
                                }
                                else if(oknoG.server == 1)
                                {
                                    string zm = Download.OneDrive.downloadVideoContent(content[position], values.name);
                                    GetListTypeEp(pageItem1, zm);
                                }
                            }
                            else
                            {
                                GetListTypeEp(pageItem1, "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video\\" + values.name + "_list_ep.txt");
                            }

                        }
                        position++;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Start>\n" + path);
                    Console.WriteLine(ex.ToString());
                    oknoG.panelLoading.Hide();
                }
                oknoG.labelLoadingDetails.Text = "Load page: " + values.name + " [100%]";
                Application.DoEvents();
                // test
                /*
                try
                {
                    string name = values.name.ToLower().Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    foreach (Control c in oknoG.flowLayoutPanelAll.Controls)
                    {
                        try
                        {
                            if (c.Tag != null)
                            {
                                WebContentControls.CtnPanel ctn = (WebContentControls.CtnPanel)c.Tag;
                                if (ctn.values.name.ToLower().Contains(name.ToLower()))
                                {
                                   pageItem1.flowLayoutPanelRelatedSeries.Controls.Add(ctn.Duplication());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                catch (Exception eex)
                {
                    Console.WriteLine(eex.ToString());
                }
                */
            }

            Task GetListTypeEp(PageItem pageItem, string path)
            {
                oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > episode list";
                Application.DoEvents();
                if (!File.Exists(path))
                {
                    pageItem.listBoxEpType.Items.Add("Brak odcinków");
                    return null;
                }
                string[] content = File.ReadAllText(path).Split(';');
                int limits = 0;
                for (int i = 0; i < content.Length; i++)
                {
                    limits = i;
                    content[i] = content[i].Replace("\n", "").Replace("\r", "").Replace("\t", "");
                }
                try
                {
                    bool end = false;
                    int position = 0;
                    while (end != true)
                    {
                        if (position == limits)
                        {
                            end = true;
                        }

                        if (content[position] == "EpisodeListed")
                        {
                            position++;
                            string zm = "[" + content[position] + "] ";
                            position++;
                            zm += content[position] + " | ";
                            position++;
                            zm += content[position] + " ;";
                            position++;
                            zm += content[position];
                            // Find the item in the list and store the index to the item.
                            int index = pageItem.listBoxEpType.FindStringExact(zm);
                            // Determine if a valid index is returned. Select the item if it is valid.
                            if (index == ListBox.NoMatches)
                            {
                                oknoG.labelLoadingDetails.Text = "Load page: " + values.name + "> load > episode list > "+zm;
                                pageItem.listBoxEpType.Items.Add(zm);
                            }
                        }

                        position++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    pageItem.listBoxEpType.Items.Add("Error: FLI02");
                    return null;
                }

                return null;
            }
        }
    }

    public class Interpreter
    {
        OknoG oknoG;
        string dirpath = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\";
        public Interpreter(OknoG okno) => oknoG = okno;

        public void Local()
        {
            if (Directory.Exists(@"C:\ContentLibrarys\OtherFiles\WMP_OverlayApp\Polecane"))
            {
                oknoG.labelLoadingDetails.Text = "Interpreter > Local > StartLocal";
                Application.DoEvents();
                StartLocal(@"C:\ContentLibrarys\OtherFiles\WMP_OverlayApp\1g4n1bVnHcI_W6WXVjScBos2dG6Kpbglk.txt");
            }
        }

        public void Start(string path)
        {
            string[] content = File.ReadAllText(path).Split(';');
            int limits = 0;
            for (int i = 0; i < content.Length; i++)
            {
                limits = i;
                content[i] = content[i].Replace("\n", "").Replace("\r", "").Replace("\t", "");
            }

            try
            {
                bool end = false;
                int position = 0;
                while (end != true)
                {
                    if (position == limits)
                    {
                        end = true;
                    }

                    if (content[position] == "GroupName")
                    {
                        position++;
                        if (content[position] == "Polecane")
                        {
                            oknoG.panePolecane.Show();
                            if (!Directory.Exists(dirpath + "Polecane"))
                            {
                                try
                                {
                                    Directory.CreateDirectory(dirpath + "Polecane");
                                }
                                catch (Exception)
                                {

                                }
                            }
                            position++;
                            if (content[position] == "dUri")
                            {
                                position++;
                                WebContent.downloadFile(content[position], dirpath + "Polecane\\" + content[position] + ".txt");
                                Interpreter interpreter = new Interpreter(oknoG);
                                interpreter.Start(dirpath + "Polecane\\" + content[position] + ".txt");

                            }
                            else if(content[position] == "oneDriveUri")
                            {
                                position++;
                                Download.OneDrive.downloadFile(content[position],
                                    dirpath + "Polecane\\" + Download.OneDrive.onedriveUri(content[position]) + ".txt");
                                Interpreter interpreter = new Interpreter(oknoG);
                                interpreter.Start(dirpath + "Polecane\\" + Download.OneDrive.onedriveUri(content[position]) + ".txt");
                            }
                        }
                        else
                        {
                            string gname = content[position];
                            AnimePlayerLibrary.ItemsGroup itemsGroup = new ItemsGroup(oknoG.panelStartPage, gname);
                            itemsGroup.Dock = DockStyle.Top;
                            oknoG.panel2.Controls.Add(itemsGroup);
                            if (!Directory.Exists(dirpath + gname))
                            {
                                try
                                {
                                    Directory.CreateDirectory(dirpath + gname);
                                }
                                catch (Exception)
                                {

                                }
                            }
                            position++;
                            if (content[position] == "dUri")
                            {
                                position++;
                                //WebContent.downloadFile(content[position], dirpath + "Polecane\\" + content[position] + ".txt");
                                oknoG.labelLoadingDetails.Text = "Interpreter > Local > StartLocal > new Interpreter > StartLocal path:" +
                                    dirpath + gname + "\\" + content[position] + ".txt";
                                Application.DoEvents();
                                WebContent.downloadFile(content[position], dirpath + gname+ "\\" + content[position] + ".txt");
                                Interpreter interpreter = new Interpreter(oknoG);
                                interpreter.Start(dirpath + gname + "\\" + content[position] + ".txt");
                            }
                            else if (content[position] == "oneDriveUri")
                            {
                                position++;
                                oknoG.labelLoadingDetails.Text = "Interpreter > Local > StartLocal > new Interpreter > StartLocal";
                                Application.DoEvents();
                                Download.OneDrive.downloadFile(content[position],
                                    dirpath + gname + "\\" + Download.OneDrive.onedriveUri(content[position]) + ".txt");
                                Interpreter interpreter = new Interpreter(oknoG);
                                interpreter.Start(dirpath + gname + "\\" + Download.OneDrive.onedriveUri(content[position]) + ".txt");
                            }
                        }

                    }
                    else if (content[position] == "Name")
                    {
                        try
                        {
                            WebContent.Values values = new WebContent.Values(path);
                            position++;
                            values.name = content[position];
                            position++;
                            if (content[position] == "Icon")
                            {
                                position++;
                                values.iconLink = content[position];
                                values.iconPath = WebContent.downloadIcon(content[position], values.name + "_icon");
                                position++;
                                if (content[position] == "Link")
                                {
                                    position++;
                                    values.siteLink = content[position];
                                    position++;
                                    if (content[position] == "ContentId")
                                    {
                                        position++;
                                        values.contentId = content[position];
                                        try
                                        {
                                            values.groupName = Path.GetDirectoryName(path);
                                        }
                                        catch (Exception)
                                        {

                                        }
                                        WebContentControls.CtnPanel panel = new WebContentControls.CtnPanel(values, oknoG);
                                    }
                                    position++;
                                    if(content[position] == "ContentId_2")
                                    {
                                        position++;
                                        values.contentId2 = content[position];
                                    }
                                    else
                                    {
                                        position--;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString() + Environment.NewLine);
                        }
                    }
                    position++;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Start>\n" + path);
                Console.WriteLine(ex.ToString());
                oknoG.panelLoading.Hide();
            }
        }


        public void StartLocal(string path)
        {
            oknoG.labelLoadingDetails.Text = "Interpreter > Local > StartLocal > file:"+path;
            if(!File.Exists(path))
            {
                oknoG.labelLoadingDetails.Text = "Interpreter > Local > StartLocal > file > Error";
                Application.DoEvents();
                return;
            }
            string[] content = File.ReadAllText(path).Split(';');
            int limits = 0;
            for (int i = 0; i < content.Length; i++)
            {
                limits = i;
                content[i] = content[i].Replace("\n", "").Replace("\r", "").Replace("\t", "");
            }

            try
            {
                bool end = false;
                int position = 0;
                while (end != true)
                {
                    if (position == limits)
                    {
                        end = true;
                    }

                    if (content[position] == "GroupName")
                    {
                        position++;
                        if (content[position] == "Polecane")
                        {
                            oknoG.panePolecane.Show();
                            if (!Directory.Exists(dirpath + "Polecane"))
                            {
                                try
                                {
                                    Directory.CreateDirectory(dirpath + "Polecane");
                                }
                                catch (Exception)
                                {

                                }
                            }
                            position++;
                            if (content[position] == "dUri")
                            {
                                position++;
                                //WebContent.downloadFile(content[position], dirpath + "Polecane\\" + content[position] + ".txt");
                                oknoG.labelLoadingDetails.Text = "Interpreter > Local > StartLocal > new Interpreter > StartLocal path:" +
                                    dirpath + "Polecane\\" + content[position] + ".txt";
                                Application.DoEvents();
                                Interpreter interpreter = new Interpreter(oknoG);
                                interpreter.StartLocal(dirpath + "Polecane\\" + content[position] + ".txt");
                            }
                            else if (content[position] == "oneDriveUri")
                            {
                                position++;
                                Interpreter interpreter = new Interpreter(oknoG);
                                interpreter.StartLocal(dirpath + "Polecane\\" + Download.OneDrive.onedriveUri(content[position]) + ".txt");
                            }
                        }
                        else
                        {
                            string gname = content[position];
                            Panel panel = new Panel();
                            panel.Show();
                            panel.Size = new Size(931, 296);
                            panel.Dock = DockStyle.Top;
                            AnimePlayerLibrary.ItemsGroup itemsGroup = new ItemsGroup(oknoG.panelStartPage, gname);
                            oknoG.panelStartPage.Controls.Add(panel);
                            panel.Controls.Add(itemsGroup);
                            itemsGroup.Dock = DockStyle.Fill;
                            oknoG.panelStartPage.Controls.SetChildIndex(panel, 0);
                            if (!Directory.Exists(dirpath + gname))
                            {
                                try
                                {
                                    Directory.CreateDirectory(dirpath + gname);
                                }
                                catch (Exception)
                                {

                                }
                            }
                            position++;
                            if (content[position] == "dUri")
                            {
                                position++;
                                //WebContent.downloadFile(content[position], dirpath + "Polecane\\" + content[position] + ".txt");
                                oknoG.labelLoadingDetails.Text = "Interpreter > Local > StartLocal > new Interpreter > StartLocal path:" +
                                    dirpath + gname + "\\" + content[position] + ".txt";
                                Application.DoEvents();
                                Interpreter interpreter = new Interpreter(oknoG);
                                interpreter.StartLocal(dirpath + gname + "\\" + content[position] + ".txt");
                            }
                            else if (content[position] == "oneDriveUri")
                            {
                                position++;
                                Interpreter interpreter = new Interpreter(oknoG);
                                interpreter.StartLocal(dirpath + gname + "\\" + Download.OneDrive.onedriveUri(content[position]) + ".txt");
                            }
                        }

                    }
                    else if (content[position] == "Name")
                    {
                        try
                        {
                            WebContent.Values values = new WebContent.Values(path);
                            position++;
                            values.name = content[position];
                            position++;
                            if (content[position] == "Icon")
                            {
                                position++;
                                values.iconLink = content[position];
                                //"C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon\\" + filename + ".png"
                                //values.iconPath = WebContent.downloadIcon(content[position], values.name + "_icon");

                                if (FindFileNameInDirIconBackup(values.name + "_icon.png"))
                                {
                                    values.iconPath = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup\\" + values.name + "_icon.png";
                                }

                                position++;
                                if (content[position] == "Link")
                                {
                                    position++;
                                    values.siteLink = content[position];
                                    position++;
                                    if (content[position] == "ContentId")
                                    {
                                        position++;
                                        values.contentId = content[position];
                                        try
                                        {
                                            values.groupName = Path.GetDirectoryName(path);
                                            if (FindFileNameInDirPage(values.name + "_page.txt"))
                                            {
                                                values.pathPage = "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Page\\" + values.name + "_page.txt";
                                            }
                                        }
                                        catch (Exception)
                                        {

                                        }
                                        oknoG.labelLoadingDetails.Text = "Interpreter > Local > StartLocal > file:" + path+ " > Create CtnPanel";
                                        WebContentControls.CtnPanel panel = new WebContentControls.CtnPanel(values, oknoG);
                                    }
                                    position++;
                                    if (content[position] == "ContentId_2")
                                    {
                                        position++;
                                        values.contentId2 = content[position];
                                    }
                                    else
                                    {
                                        position--;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString() + Environment.NewLine);
                        }
                    }
                    position++;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Start>\n" + path);
                Console.WriteLine(ex.ToString());
                oknoG.panelLoading.Hide();
            }
        }

        public bool FindFileNameInDirIcon(string filename)
        {
            DirectoryInfo di = new DirectoryInfo("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Icon");

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name == filename)
                {
                    return true;
                }
            }
            return false;
        }
        public bool FindFileNameInDirIconBackup(string filename)
        {
            DirectoryInfo di = new DirectoryInfo("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\IconBackup");

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name == filename)
                {
                    return true;
                }
            }
            return false;
        }

        public bool FindFileNameInDirPage(string filename)
        {
            DirectoryInfo di = new DirectoryInfo("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Page");

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name == filename)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
