using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimePlayerLibrary
{
    public partial class NewsPageContent : UserControl
    {
        ListNews news;
        public NewsPageContent(ListNews listnews)
        {
            InitializeComponent();
            try
            {
                news = listnews;
                Download.File(news.ContentLink, DefaultAppDire.Temp + news.ID + "_newspage.txt");
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void SetContentPage()
        {
            try
            {
                string path = DefaultAppDire.Temp + news.ID + "_newspage.txt";
                if (path == null)
                {
                    return;
                }
                string[] content = File.ReadAllText(path).Split(';');
                int limits = 0;
                for (int i = 0; i < content.Length; i++)
                {
                    limits = i;
                    content[i] = content[i].Replace("\n", "").Replace("\r", "").Replace("\t", "");
                }

                bool end = false;
                int position = 0;
                while (end != true)
                {
                    if (position == limits)
                    {
                        end = true;
                    }

                    if (content[position] == "Image")
                    {
                        position++;
                        if(content[position] =="Link")
                        {
                            position++;
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.ImageLocation = content[position];
                            position++;
                            if(content[position]=="Size")
                            {
                                position++;
                                int x = int.Parse(content[position]);
                                position++;
                                pictureBox.Size = new Size(x, int.Parse(content[position]));
                                pictureBox.Dock = DockStyle.Top;
                            }
                        }
                    }
                    else if (content[position] == "Label")
                    {
                        Label label = new Label();
                        position++;
                        if(content[position]=="Text")
                        {
                            position++;
                            label.Text = content[position];
                            position++;
                            if (content[position] == "Size")
                            {
                                position++;
                                int x = int.Parse(content[position]);
                                position++;
                                label.Size = new Size(x, int.Parse(content[position]));
                                label.Dock = DockStyle.Top;
                            }
                        }
                    }
                    else if (content[position] == "ButtonOpenLink")
                    {
                        position++;
                        Button button = new Button();
                        button.Click += ButtonOpenLink_Click;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 0;
                        button.Tag = content[position];
                        position++;
                        if (content[position] == "Text")
                        {
                            position++;
                            button.Text = content[position];
                            position++;
                            if (content[position] == "Size")
                            {
                                position++;
                                int x = int.Parse(content[position]);
                                position++;
                                button.Size = new Size(x, int.Parse(content[position]));
                                button.Dock = DockStyle.Top;
                            }
                        }
                    }
                    position++;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ButtonOpenLink_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                System.Diagnostics.Process.Start(button.Tag.ToString());
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
