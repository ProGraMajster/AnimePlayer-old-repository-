using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimePlayer
{
    public partial class PageEpisode : UserControl
    {
        private Panel panelvv;
        public string nameTypeEpisode;
        public string pathToFile;
        WebContent.Values values;
        public PageEpisode(string name, string path, WebContent.Values val, Panel panel)
        {
            InitializeComponent();
            panelvv = panel;
            values = val;
            nameTypeEpisode = name;
            pathToFile = path;
            this.Load += PageEpisode_Load;
            pictureBox1.LoadAsync(val.iconPath);
            labelTitle.Text = val.name;
        }

        private void PageEpisode_Load(object sender, EventArgs e)
        {
            GetEpisode(pathToFile);
        }

        Task GetEpisode(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("Nie udało się załadować zawartości");
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
                        if (zm == nameTypeEpisode)
                        {
                            position++;
                            int ep = int.Parse(content[position]);
                            position++;
                            if (content[position] == "Quality")
                            {
                                position++;
                                int num_btn = int.Parse(content[position]);
                                string ep_link = null;
                                for (int i = 0; i < num_btn; i++)
                                {
                                    position++;
                                    ep_link += content[position]+";";
                                }

                                ClassEpisodePanel episodePanel = new ClassEpisodePanel(zm, ep, num_btn, path, ep_link, panelvv);
                                flowLayoutPanel1.Controls.Add(episodePanel.panelMain);
                            }
                        }
                    }

                    position++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Nie udało się załadować zawartości");
                return null;
            }

            return null;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelViewIcon.Size = new Size(this.Size.Width - 200, this.Size.Height - 100);
            panelViewIcon.Left = (this.ClientSize.Width - panelViewIcon.Width) / 2;
            panelViewIcon.Top = (this.ClientSize.Height - panelViewIcon.Height) / 2;
            
            panelViewIcon.BringToFront();
            panelViewIcon.Show();
            pictureBox2.Image = pictureBox1.Image;
        }

        private void buttonViewIconClose_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            panelViewIcon.Hide();
        }

        private void PageEpisode_Resize(object sender, EventArgs e)
        {
            if(panelViewIcon.Visible)
            {
                panelViewIcon.Size = new Size(this.Size.Width - 200, this.Size.Height - 100);
                panelViewIcon.Left = (this.ClientSize.Width - panelViewIcon.Width) / 2;
                panelViewIcon.Top = (this.ClientSize.Height - panelViewIcon.Height) / 2;
            }
        }
    }
}
