using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnimePlayer
{
    public partial class PageItem : UserControl
    {
        WebContent.Values values;
        OknoG oknoG;
        public PageItem()
        {
            InitializeComponent();
        }

        public PageItem(WebContent.Values va, OknoG okno)
        {
            InitializeComponent();
            oknoG = okno;
            values = va;
            if (values != null)
            {
                linkLabel1.Show();
            }
            else
            {
                linkLabel1.Hide();
            }

            if (AnimePlayer.Properties.Settings.Default.RoundingControl)
            {
                ControlsNewMethods.RoundingControl rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = pictureBoxIcon;
                rc.CornerRadius = 20;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = panelViewIcon;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = labelotherTitle;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = labelTitle;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = button;
                rc.CornerRadius = 15;
            }
        }


        private void button_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (values != null)
            {
                if (values.siteLink != null && values.siteLink != "null")
                {
                    DialogResult dr = MessageBox.Show("Czy otworzy link?", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(values.siteLink);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listBoxEpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (values != null)
                {
                    if (File.Exists("C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video\\" + values.name + "_list_ep.txt"))
                    {
                        if (listBoxEpType.SelectedItem.ToString() != null)
                        {
                            PageEpisode pageEpisode = new PageEpisode(listBoxEpType.SelectedItem.ToString(),
                                "C:\\ContentLibrarys\\OtherFiles\\WMP_OverlayApp\\Video\\" + values.name + "_list_ep.txt", values, oknoG.panel2);

                            oknoG.panel2.Controls.Add(pageEpisode);
                            pageEpisode.Dock = DockStyle.Fill;
                            pageEpisode.Show();
                            pageEpisode.BringToFront();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            panelViewIcon.Size = new Size(this.Size.Width - 200, this.Size.Height - 100);
            panelViewIcon.Left = (this.ClientSize.Width - panelViewIcon.Width) / 2;
            panelViewIcon.Top = (this.ClientSize.Height - panelViewIcon.Height) / 2;

            panelViewIcon.BringToFront();
            panelViewIcon.Show();
            pictureBox2.Image = pictureBoxIcon.Image;
        }

        private void buttonViewIconClose_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            panelViewIcon.Hide();
        }
    }
}
