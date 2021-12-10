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

        public bool use = false;
        public bool use_Species = false;

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
            }
        }

        // Jeszcze trzeba to skończyć...
        #region Species

        public string[] str_Species = { "akcja", "Cyberpunk", "Dramat", "Ecchi", "Eksperymentalne", "Fantasy", "Harem", "Hentai", "Historyczne", "Horror", "Komedia", "Kryminalne", "Magia", "Mecha", "Męski harem", "Muzyczne", "Nadprzyrodzone", "Obłęd", "Okruchy życia", "Parodia" };
        public int Akcja = 1;//1
        public int Cyberpunk = 1;//2
        public int Dramat = 1;//3
        public int Ecchi = 1;//4
        public int Eksperymentalne = 1;//5
        public int Fantasy = 1;//6
        public int Harem = 1;//7
        public int Hentai = 1;//8
        public int Historyczne = 1;//9
        public int Horror = 1;//10
        public int Komedia = 1;//11
        public int Kryminalne = 1;//12
        public int Magia = 1;
        public int Mecha = 1;
        public int Męski_harem = 1;
        public int Muzyczne = 1;
        public int Nadprzyrodzone = 1;
        public int Obłęd = 1;
        public int Okruchy_życia = 1;
        public int Parodia = 1;
        public int Przygodowe = 1;
        public int Psychologiczne = 1;
        public int Romans = 1;
        public int Sci_Fi = 1;
        public int Shoujo_ai = 1;
        public int Shounen_ai = 1;
        public int Space_opera = 1;
        public int Sportowe = 1;
        public int Steampunk = 1;
        public int Szkolne = 1;
        public int Sztuki_walki = 1;
        public int Tajemnica = 1;
        public int Thriller = 1;
        public int Wojskowe = 1;
        public int Yaoi = 1;
        public int Yuri = 1;

        #endregion

        private bool flags_findItem = false;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(use == true)
            {
                use = false;
                return;
            }
            if(use == false)
            {
                use = true;
                return;
            }
        }
    }
}
