using System;
using System.Windows.Forms;

namespace AnimePlayer
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new OknoG());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił krytyczny błąd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("CrashApplogs.txt", ex.ToString() + Environment.NewLine);
            }
        }
    }
}
