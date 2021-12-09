using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimePlayerLibrary
{
    public partial class PanelSearchFilters : UserControl
    {
        public Control _source;
        public Control _output;

        public PanelSearchFilters(Control source, Control output, bool flag = true)
        {
            InitializeComponent();
            if(flag)
            {
                ControlsNewMethods.RoundingControl rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = this;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = panelSpecies;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = buttonSpecies;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = buttonClose;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = buttonReset;
                rc.CornerRadius = 15;
                rc = new ControlsNewMethods.RoundingControl();
                rc.TargetControl = buttonFind;
                rc.CornerRadius = 15;
            }
        }

        #region Species

        int Akcja = 0;
        int Cyberpunk = 0;
        int Dramat = 0;
        int Ecchi = 0;
        int Eksperymentalne = 0;
        int Fantasy = 0;
        int Harem = 0;
        int Hentai = 0;
        int Historyczne = 0;
        int Horror = 0;
        int Komedia = 0;
        int Kryminalne = 0;
        int Magia = 0;
        int Mecha = 0;
        int Męski_harem = 0;
        int Muzyczne = 0;
        int Nadprzyrodzone = 0;
        int Obłęd = 0;
        int Okruchy_życia = 0;
        int Parodia = 0;
        int Przygodowe = 0;
        int Psychologiczne = 0;
        int Romans = 0;
        int Sci_Fi = 0;
        int Shoujo_ai = 0;
        int Shounen_ai = 0;
        int Space_opera = 0;
        int Sportowe = 0;
        int Steampunk = 0;
        int Szkolne = 0;
        int Sztuki_walki = 0;
        int Tajemnica = 0;
        int Thriller = 0;
        int Wojskowe = 0;
        int Yaoi = 0;
        int Yuri = 0;

        #endregion

        private bool flags_findItem = false;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            
        }


        public void findTitiles()
        {
            flags_findItem = true;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string findText = textBoxFinditem.Text.ToLower().Replace("\n", "").Replace("\r", "").Replace("\t", "");
            if (textBoxFinditem.Text == null)
            {
                //flowLayoutPanelFinditem.Hide();
                //labelFindSatus.Hide();
                //labelFindSatus.Text = "";
                flags_findItem = false;
                return;
            }
            int i = 0;
            //flowLayoutPanelFinditem.Controls.Clear();
            //labelFindSatus.Show();
            //flowLayoutPanelAll.Hide();
            try
            {
                //labelFindSatus.Text = "Szukanie";
                Application.DoEvents();
                foreach (Control c in _source.Controls)
                {
                    try
                    {
                        //labelFindSatus.Text += ".";
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                textBoxFinditem.Text = findText;
                //labelFindSatus.Text = "Znaleziono: " + i;
                //flowLayoutPanelFinditem.Show();
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
    }
}
