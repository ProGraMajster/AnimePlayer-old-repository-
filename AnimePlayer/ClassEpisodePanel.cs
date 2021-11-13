using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace AnimePlayer
{
    public class ClassEpisodePanel
    {

        public Panel panelMain;
        public Label labelTitle;
        public Label labelEp;

        public Button button_1080p;
        public Button button_720p;
        public Button button_460p;
        public Button button_360p;
        public int NumberBtn;
        public int numEp;


        public ClassEpisodePanel(string text, int ep, int numberQuality, string path, string link)
        {
            panelMain = new Panel();
            panelMain.BackColor = Color.FromArgb(30, 30, 30);
            panelMain.Size = new Size(700, 30);

            labelTitle = new Label();
            labelTitle.Dock = DockStyle.Left;
            labelTitle.Text = text;
            labelTitle.Size = new Size(100, 30);
            labelTitle.AutoSize = true;
            labelTitle.AutoEllipsis = true;
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;


            labelEp = new Label();
            labelEp.Dock = DockStyle.Left;
            labelEp.BackColor = Color.FromArgb(35, 35, 35);
            labelEp.Text = "Odcinek: "+ep;
            labelEp.Size = new Size(100, 30);
            labelEp.AutoSize = true;
            labelEp.AutoEllipsis = true;
            labelEp.ForeColor = Color.White;
            labelEp.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            labelEp.TextAlign = ContentAlignment.MiddleLeft;

            button_1080p = new Button();
            button_1080p.Size = new Size(50, 30);
            button_1080p.FlatStyle = FlatStyle.Flat;
            button_1080p.ForeColor = Color.White;
            button_1080p.Dock = DockStyle.Right;
            button_1080p.Text = "1080p";
            button_1080p.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            button_1080p.AutoSize = true;

            button_720p = new Button();
            button_720p.Size = new Size(50, 30);
            button_720p.FlatStyle = FlatStyle.Flat;
            button_720p.ForeColor = Color.White;
            button_720p.Dock = DockStyle.Right;
            button_720p.Text = "720p";
            button_720p.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            button_720p.AutoSize = true;

            button_460p = new Button();
            button_460p.Size = new Size(50, 30);
            button_460p.FlatStyle = FlatStyle.Flat;
            button_460p.ForeColor = Color.White;
            button_460p.Dock = DockStyle.Right;
            button_460p.Text = "460p";
            button_460p.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            button_460p.AutoSize = true;

            button_360p = new Button();
            button_360p.Size = new Size(50, 30);
            button_360p.FlatStyle = FlatStyle.Flat;
            button_360p.ForeColor = Color.White;
            button_360p.Dock = DockStyle.Right;
            button_360p.Text = "360p";
            button_360p.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            button_360p.AutoSize = true;

            panelMain.Controls.Add(button_1080p);
            panelMain.Controls.Add(button_720p);
            panelMain.Controls.Add(button_460p);
            panelMain.Controls.Add(button_360p);
            panelMain.Controls.Add(labelEp);
            panelMain.Controls.Add(labelTitle);
        }


    }
}
