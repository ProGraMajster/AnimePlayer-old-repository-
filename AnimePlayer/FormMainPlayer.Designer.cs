namespace AnimePlayer
{
    partial class OknoG
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMainPlayer = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelYTlink = new System.Windows.Forms.Panel();
            this.buttonYTlinkClose = new System.Windows.Forms.Button();
            this.buttonUseYTlink = new System.Windows.Forms.Button();
            this.textBoxYTlink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panelWeb = new System.Windows.Forms.Panel();
            this.buttonCloseWeb = new System.Windows.Forms.Button();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.panelStartPage = new System.Windows.Forms.Panel();
            this.panelGroup = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panePolecane = new System.Windows.Forms.Panel();
            this.flowLayoutPanelPolecane = new System.Windows.Forms.FlowLayoutPanel();
            this.panelItem = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.roundedPanel1 = new AnimePlayer.RoundedPanel();
            this.labelSatusWorkingApp = new System.Windows.Forms.Label();
            this.buttonMenuOpen = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonExitApp = new System.Windows.Forms.Button();
            this.buttonPlayer = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.buttonMenuClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelNotifiError = new System.Windows.Forms.Panel();
            this.labelError = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timerAnimationError = new System.Windows.Forms.Timer(this.components);
            this.panelYTlink.SuspendLayout();
            this.panelWeb.SuspendLayout();
            this.panelPlayer.SuspendLayout();
            this.panelStartPage.SuspendLayout();
            this.panelGroup.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panePolecane.SuspendLayout();
            this.flowLayoutPanelPolecane.SuspendLayout();
            this.panelItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelLoading.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelNotifiError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMainPlayer
            // 
            this.panelMainPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainPlayer.Location = new System.Drawing.Point(0, 0);
            this.panelMainPlayer.Name = "panelMainPlayer";
            this.panelMainPlayer.Size = new System.Drawing.Size(948, 541);
            this.panelMainPlayer.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "WMP_OverlayApp";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // panelYTlink
            // 
            this.panelYTlink.Controls.Add(this.buttonYTlinkClose);
            this.panelYTlink.Controls.Add(this.buttonUseYTlink);
            this.panelYTlink.Controls.Add(this.textBoxYTlink);
            this.panelYTlink.Controls.Add(this.label1);
            this.panelYTlink.Location = new System.Drawing.Point(145, 57);
            this.panelYTlink.Name = "panelYTlink";
            this.panelYTlink.Size = new System.Drawing.Size(346, 95);
            this.panelYTlink.TabIndex = 4;
            // 
            // buttonYTlinkClose
            // 
            this.buttonYTlinkClose.Location = new System.Drawing.Point(308, 3);
            this.buttonYTlinkClose.Name = "buttonYTlinkClose";
            this.buttonYTlinkClose.Size = new System.Drawing.Size(35, 23);
            this.buttonYTlinkClose.TabIndex = 3;
            this.buttonYTlinkClose.Text = "X";
            this.buttonYTlinkClose.UseVisualStyleBackColor = true;
            this.buttonYTlinkClose.Click += new System.EventHandler(this.buttonYTlinkClose_Click);
            // 
            // buttonUseYTlink
            // 
            this.buttonUseYTlink.Location = new System.Drawing.Point(135, 69);
            this.buttonUseYTlink.Name = "buttonUseYTlink";
            this.buttonUseYTlink.Size = new System.Drawing.Size(75, 23);
            this.buttonUseYTlink.TabIndex = 2;
            this.buttonUseYTlink.Text = "Ok";
            this.buttonUseYTlink.UseVisualStyleBackColor = true;
            this.buttonUseYTlink.Click += new System.EventHandler(this.buttonUseYTlink_Click);
            // 
            // textBoxYTlink
            // 
            this.textBoxYTlink.Location = new System.Drawing.Point(21, 40);
            this.textBoxYTlink.Name = "textBoxYTlink";
            this.textBoxYTlink.Size = new System.Drawing.Size(301, 20);
            this.textBoxYTlink.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(132, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj link";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 23);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(948, 518);
            this.webBrowser1.TabIndex = 4;
            // 
            // panelWeb
            // 
            this.panelWeb.Controls.Add(this.webBrowser1);
            this.panelWeb.Controls.Add(this.buttonCloseWeb);
            this.panelWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWeb.Location = new System.Drawing.Point(0, 0);
            this.panelWeb.Name = "panelWeb";
            this.panelWeb.Size = new System.Drawing.Size(948, 541);
            this.panelWeb.TabIndex = 5;
            // 
            // buttonCloseWeb
            // 
            this.buttonCloseWeb.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCloseWeb.Location = new System.Drawing.Point(0, 0);
            this.buttonCloseWeb.Name = "buttonCloseWeb";
            this.buttonCloseWeb.Size = new System.Drawing.Size(948, 23);
            this.buttonCloseWeb.TabIndex = 5;
            this.buttonCloseWeb.Text = "Zamknij";
            this.buttonCloseWeb.UseVisualStyleBackColor = true;
            this.buttonCloseWeb.Click += new System.EventHandler(this.buttonCloseWeb_Click);
            // 
            // panelPlayer
            // 
            this.panelPlayer.Controls.Add(this.panelMainPlayer);
            this.panelPlayer.Controls.Add(this.panelWeb);
            this.panelPlayer.Controls.Add(this.panelYTlink);
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(948, 541);
            this.panelPlayer.TabIndex = 6;
            // 
            // panelStartPage
            // 
            this.panelStartPage.AutoScroll = true;
            this.panelStartPage.Controls.Add(this.panelGroup);
            this.panelStartPage.Controls.Add(this.panePolecane);
            this.panelStartPage.Controls.Add(this.panelTop);
            this.panelStartPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStartPage.Location = new System.Drawing.Point(0, 0);
            this.panelStartPage.Name = "panelStartPage";
            this.panelStartPage.Size = new System.Drawing.Size(948, 541);
            this.panelStartPage.TabIndex = 6;
            // 
            // panelGroup
            // 
            this.panelGroup.Controls.Add(this.flowLayoutPanel2);
            this.panelGroup.Controls.Add(this.panel4);
            this.panelGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGroup.Location = new System.Drawing.Point(0, 387);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(931, 296);
            this.panelGroup.TabIndex = 4;
            this.panelGroup.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(931, 266);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(13, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(177, 241);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::AnimePlayer.Properties.Resource.NoImage;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(177, 199);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Location = new System.Drawing.Point(0, 199);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 42);
            this.button3.TabIndex = 1;
            this.button3.Text = "Name";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel4.Size = new System.Drawing.Size(931, 30);
            this.panel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "TitleGroup";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panePolecane
            // 
            this.panePolecane.Controls.Add(this.flowLayoutPanelPolecane);
            this.panePolecane.Controls.Add(this.panel1);
            this.panePolecane.Dock = System.Windows.Forms.DockStyle.Top;
            this.panePolecane.Location = new System.Drawing.Point(0, 91);
            this.panePolecane.Name = "panePolecane";
            this.panePolecane.Size = new System.Drawing.Size(931, 296);
            this.panePolecane.TabIndex = 3;
            this.panePolecane.Visible = false;
            // 
            // flowLayoutPanelPolecane
            // 
            this.flowLayoutPanelPolecane.AutoScroll = true;
            this.flowLayoutPanelPolecane.Controls.Add(this.panelItem);
            this.flowLayoutPanelPolecane.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelPolecane.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanelPolecane.Name = "flowLayoutPanelPolecane";
            this.flowLayoutPanelPolecane.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.flowLayoutPanelPolecane.Size = new System.Drawing.Size(931, 266);
            this.flowLayoutPanelPolecane.TabIndex = 1;
            this.flowLayoutPanelPolecane.WrapContents = false;
            // 
            // panelItem
            // 
            this.panelItem.Controls.Add(this.pictureBox1);
            this.panelItem.Controls.Add(this.button2);
            this.panelItem.Location = new System.Drawing.Point(13, 5);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(177, 241);
            this.panelItem.TabIndex = 0;
            this.panelItem.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::AnimePlayer.Properties.Resource.NoImage;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(0, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Name";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel1.Size = new System.Drawing.Size(931, 30);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Polecane";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.roundedPanel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelTop.Size = new System.Drawing.Size(931, 91);
            this.panelTop.TabIndex = 0;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedPanel1.ColorEdges = System.Drawing.SystemColors.ActiveCaptionText;
            this.roundedPanel1.Controls.Add(this.labelSatusWorkingApp);
            this.roundedPanel1.Controls.Add(this.buttonMenuOpen);
            this.roundedPanel1.Controls.Add(this.label);
            this.roundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel1.ExBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.roundedPanel1.Location = new System.Drawing.Point(10, 10);
            this.roundedPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
            this.roundedPanel1.RadiusArcPanel = 15F;
            this.roundedPanel1.Size = new System.Drawing.Size(911, 71);
            this.roundedPanel1.TabIndex = 0;
            this.roundedPanel1.Resize += new System.EventHandler(this.Panel_Resize);
            // 
            // labelSatusWorkingApp
            // 
            this.labelSatusWorkingApp.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelSatusWorkingApp.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSatusWorkingApp.ForeColor = System.Drawing.SystemColors.Window;
            this.labelSatusWorkingApp.Location = new System.Drawing.Point(598, 6);
            this.labelSatusWorkingApp.Name = "labelSatusWorkingApp";
            this.labelSatusWorkingApp.Size = new System.Drawing.Size(222, 59);
            this.labelSatusWorkingApp.TabIndex = 2;
            this.labelSatusWorkingApp.Text = "Satus działania:";
            this.labelSatusWorkingApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonMenuOpen
            // 
            this.buttonMenuOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMenuOpen.FlatAppearance.BorderSize = 0;
            this.buttonMenuOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.buttonMenuOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.buttonMenuOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuOpen.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMenuOpen.ForeColor = System.Drawing.Color.White;
            this.buttonMenuOpen.Location = new System.Drawing.Point(820, 6);
            this.buttonMenuOpen.Name = "buttonMenuOpen";
            this.buttonMenuOpen.Size = new System.Drawing.Size(71, 59);
            this.buttonMenuOpen.TabIndex = 1;
            this.buttonMenuOpen.Text = "=";
            this.buttonMenuOpen.UseVisualStyleBackColor = true;
            this.buttonMenuOpen.Click += new System.EventHandler(this.buttonMenuOpen_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.Window;
            this.label.Location = new System.Drawing.Point(32, 22);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(150, 28);
            this.label.TabIndex = 0;
            this.label.Text = "Twoje anime pl";
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(10);
            this.panelSettings.Size = new System.Drawing.Size(948, 541);
            this.panelSettings.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ustawienia";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLoading
            // 
            this.panelLoading.Controls.Add(this.labelLoading);
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoading.Location = new System.Drawing.Point(0, 0);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(948, 541);
            this.panelLoading.TabIndex = 2;
            this.panelLoading.VisibleChanged += new System.EventHandler(this.panelLoading_VisibleChanged);
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLoading.ForeColor = System.Drawing.Color.White;
            this.labelLoading.Location = new System.Drawing.Point(355, 237);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(166, 38);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "Ładowanie...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLoading.VisibleChanged += new System.EventHandler(this.labelLoading_VisibleChanged);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonExitApp);
            this.panelMenu.Controls.Add(this.buttonPlayer);
            this.panelMenu.Controls.Add(this.buttonSetting);
            this.panelMenu.Controls.Add(this.buttonMenuClose);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(10);
            this.panelMenu.Size = new System.Drawing.Size(200, 541);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.Visible = false;
            // 
            // buttonExitApp
            // 
            this.buttonExitApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonExitApp.FlatAppearance.BorderSize = 0;
            this.buttonExitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitApp.ForeColor = System.Drawing.Color.White;
            this.buttonExitApp.Location = new System.Drawing.Point(10, 118);
            this.buttonExitApp.Name = "buttonExitApp";
            this.buttonExitApp.Size = new System.Drawing.Size(180, 40);
            this.buttonExitApp.TabIndex = 3;
            this.buttonExitApp.Text = "Zamknij aplikacje";
            this.buttonExitApp.UseVisualStyleBackColor = true;
            this.buttonExitApp.Click += new System.EventHandler(this.buttonExitApp_Click);
            // 
            // buttonPlayer
            // 
            this.buttonPlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPlayer.FlatAppearance.BorderSize = 0;
            this.buttonPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayer.ForeColor = System.Drawing.Color.White;
            this.buttonPlayer.Location = new System.Drawing.Point(10, 78);
            this.buttonPlayer.Name = "buttonPlayer";
            this.buttonPlayer.Size = new System.Drawing.Size(180, 40);
            this.buttonPlayer.TabIndex = 2;
            this.buttonPlayer.Text = "Odtwarzacz";
            this.buttonPlayer.UseVisualStyleBackColor = true;
            this.buttonPlayer.Click += new System.EventHandler(this.buttonPlayer_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSetting.FlatAppearance.BorderSize = 0;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.ForeColor = System.Drawing.Color.White;
            this.buttonSetting.Location = new System.Drawing.Point(10, 38);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(180, 40);
            this.buttonSetting.TabIndex = 1;
            this.buttonSetting.Text = "Ustawienia";
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // buttonMenuClose
            // 
            this.buttonMenuClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMenuClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuClose.ForeColor = System.Drawing.Color.Red;
            this.buttonMenuClose.Location = new System.Drawing.Point(10, 10);
            this.buttonMenuClose.Name = "buttonMenuClose";
            this.buttonMenuClose.Size = new System.Drawing.Size(180, 28);
            this.buttonMenuClose.TabIndex = 0;
            this.buttonMenuClose.Text = "X";
            this.buttonMenuClose.UseVisualStyleBackColor = true;
            this.buttonMenuClose.Click += new System.EventHandler(this.buttonMenuClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelStartPage);
            this.panel2.Controls.Add(this.panelPlayer);
            this.panel2.Controls.Add(this.panelSettings);
            this.panel2.Controls.Add(this.panelLoading);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(948, 541);
            this.panel2.TabIndex = 5;
            // 
            // panelNotifiError
            // 
            this.panelNotifiError.Controls.Add(this.labelError);
            this.panelNotifiError.Controls.Add(this.pictureBox3);
            this.panelNotifiError.Location = new System.Drawing.Point(0, 0);
            this.panelNotifiError.Name = "panelNotifiError";
            this.panelNotifiError.Size = new System.Drawing.Size(200, 51);
            this.panelNotifiError.TabIndex = 6;
            // 
            // labelError
            // 
            this.labelError.AutoEllipsis = true;
            this.labelError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelError.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(57, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(143, 51);
            this.labelError.TabIndex = 1;
            this.labelError.Text = "Error code:";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = global::AnimePlayer.Properties.Resource.error;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // timerAnimationError
            // 
            this.timerAnimationError.Interval = 1;
            this.timerAnimationError.Tick += new System.EventHandler(this.timerAnimationError_Tick);
            // 
            // OknoG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(948, 541);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelNotifiError);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "OknoG";
            this.Text = "WMP_OverlayApp - Twojeanimepl";
            this.Load += new System.EventHandler(this.OknoG_Load);
            this.ResizeEnd += new System.EventHandler(this.OknoG_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panelYTlink.ResumeLayout(false);
            this.panelYTlink.PerformLayout();
            this.panelWeb.ResumeLayout(false);
            this.panelPlayer.ResumeLayout(false);
            this.panelStartPage.ResumeLayout(false);
            this.panelGroup.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panePolecane.ResumeLayout(false);
            this.flowLayoutPanelPolecane.ResumeLayout(false);
            this.panelItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelLoading.ResumeLayout(false);
            this.panelLoading.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelNotifiError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMainPlayer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel panelYTlink;
        private System.Windows.Forms.Button buttonYTlinkClose;
        private System.Windows.Forms.Button buttonUseYTlink;
        private System.Windows.Forms.TextBox textBoxYTlink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panelWeb;
        private System.Windows.Forms.Button buttonCloseWeb;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelStartPage;
        private System.Windows.Forms.Panel panelTop;
        private AnimePlayer.RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonMenuOpen;
        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel panePolecane;
        private System.Windows.Forms.Label labelLoading;
        public System.Windows.Forms.Panel panelLoading;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPolecane;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonMenuClose;
        private System.Windows.Forms.Button buttonPlayer;
        private System.Windows.Forms.Button buttonSetting;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonExitApp;
        private System.Windows.Forms.Panel panelNotifiError;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Label labelError;
        public System.Windows.Forms.Timer timerAnimationError;
        public System.Windows.Forms.Label labelSatusWorkingApp;
    }
}

