
namespace AnimePlayer
{
    partial class FormMiniPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDoprzodu = new System.Windows.Forms.Button();
            this.buttonControlP = new System.Windows.Forms.Button();
            this.buttonDotylu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBoxFile = new System.Windows.Forms.PictureBox();
            this.labelNameFile = new System.Windows.Forms.Label();
            this.timerKontrol = new System.Windows.Forms.Timer(this.components);
            this.labelCzas = new System.Windows.Forms.Label();
            this.panelMainP = new System.Windows.Forms.Panel();
            this.buttonDP = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonG = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFile)).BeginInit();
            this.panelMainP.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDoprzodu);
            this.panel1.Controls.Add(this.buttonControlP);
            this.panel1.Controls.Add(this.buttonDotylu);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 45);
            this.panel1.TabIndex = 0;
            // 
            // buttonDoprzodu
            // 
            this.buttonDoprzodu.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDoprzodu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDoprzodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDoprzodu.Location = new System.Drawing.Point(177, 0);
            this.buttonDoprzodu.Name = "buttonDoprzodu";
            this.buttonDoprzodu.Size = new System.Drawing.Size(59, 45);
            this.buttonDoprzodu.TabIndex = 3;
            this.buttonDoprzodu.Text = ">>";
            this.buttonDoprzodu.UseVisualStyleBackColor = true;
            this.buttonDoprzodu.Click += new System.EventHandler(this.buttonDoprzodu_Click);
            // 
            // buttonControlP
            // 
            this.buttonControlP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonControlP.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonControlP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControlP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonControlP.Location = new System.Drawing.Point(118, 0);
            this.buttonControlP.Name = "buttonControlP";
            this.buttonControlP.Size = new System.Drawing.Size(59, 45);
            this.buttonControlP.TabIndex = 2;
            this.buttonControlP.Text = "pause";
            this.buttonControlP.UseVisualStyleBackColor = true;
            this.buttonControlP.Click += new System.EventHandler(this.buttonControlP_Click);
            // 
            // buttonDotylu
            // 
            this.buttonDotylu.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDotylu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDotylu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDotylu.Location = new System.Drawing.Point(59, 0);
            this.buttonDotylu.Name = "buttonDotylu";
            this.buttonDotylu.Size = new System.Drawing.Size(59, 45);
            this.buttonDotylu.TabIndex = 1;
            this.buttonDotylu.Text = "<<";
            this.buttonDotylu.UseVisualStyleBackColor = true;
            this.buttonDotylu.Click += new System.EventHandler(this.buttonDotylu_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = ". . .";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBoxFile
            // 
            this.pictureBoxFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxFile.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFile.Name = "pictureBoxFile";
            this.pictureBoxFile.Size = new System.Drawing.Size(165, 85);
            this.pictureBoxFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFile.TabIndex = 1;
            this.pictureBoxFile.TabStop = false;
            // 
            // labelNameFile
            // 
            this.labelNameFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNameFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNameFile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNameFile.Location = new System.Drawing.Point(165, 0);
            this.labelNameFile.Name = "labelNameFile";
            this.labelNameFile.Size = new System.Drawing.Size(285, 37);
            this.labelNameFile.TabIndex = 2;
            this.labelNameFile.Text = "label1";
            this.labelNameFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerKontrol
            // 
            this.timerKontrol.Tick += new System.EventHandler(this.timerKontrol_Tick);
            // 
            // labelCzas
            // 
            this.labelCzas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCzas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelCzas.Location = new System.Drawing.Point(165, 65);
            this.labelCzas.Name = "labelCzas";
            this.labelCzas.Size = new System.Drawing.Size(285, 20);
            this.labelCzas.TabIndex = 3;
            this.labelCzas.Text = "Czas: 00.00 - 00.00";
            this.labelCzas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMainP
            // 
            this.panelMainP.Controls.Add(this.labelCzas);
            this.panelMainP.Controls.Add(this.labelNameFile);
            this.panelMainP.Controls.Add(this.pictureBoxFile);
            this.panelMainP.Controls.Add(this.panel1);
            this.panelMainP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainP.Location = new System.Drawing.Point(0, 10);
            this.panelMainP.Name = "panelMainP";
            this.panelMainP.Size = new System.Drawing.Size(450, 130);
            this.panelMainP.TabIndex = 4;
            // 
            // buttonDP
            // 
            this.buttonDP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDP.Location = new System.Drawing.Point(450, 140);
            this.buttonDP.Name = "buttonDP";
            this.buttonDP.Size = new System.Drawing.Size(10, 10);
            this.buttonDP.TabIndex = 4;
            this.buttonDP.UseVisualStyleBackColor = true;
            // 
            // buttonD
            // 
            this.buttonD.BackColor = System.Drawing.Color.Transparent;
            this.buttonD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonD.Location = new System.Drawing.Point(0, 140);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(460, 10);
            this.buttonD.TabIndex = 5;
            this.buttonD.UseVisualStyleBackColor = false;
            // 
            // buttonG
            // 
            this.buttonG.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonG.Location = new System.Drawing.Point(0, 0);
            this.buttonG.Name = "buttonG";
            this.buttonG.Size = new System.Drawing.Size(450, 10);
            this.buttonG.TabIndex = 6;
            this.buttonG.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(450, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(10, 140);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FormMiniPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(460, 150);
            this.Controls.Add(this.panelMainP);
            this.Controls.Add(this.buttonDP);
            this.Controls.Add(this.buttonG);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonD);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1210, 710);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMiniPlayer";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AnimePlayer";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFile)).EndInit();
            this.panelMainP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDoprzodu;
        private System.Windows.Forms.Button buttonDotylu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBoxFile;
        private System.Windows.Forms.Label labelNameFile;
        public System.Windows.Forms.Button buttonControlP;
        private System.Windows.Forms.Timer timerKontrol;
        private System.Windows.Forms.Label labelCzas;
        private System.Windows.Forms.Panel panelMainP;
        private System.Windows.Forms.Button buttonDP;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonG;
        private System.Windows.Forms.Button button3;
    }
}