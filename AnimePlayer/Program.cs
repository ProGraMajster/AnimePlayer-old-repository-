using System;
using System.IO;
using System.Net;
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
                bool updates = false;
                foreach(string arg in Environment.GetCommandLineArgs())
                {

                    if(arg == "/Checking_update")
                    {
                        updates = true;
                    }
                }

                if(updates == false)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new OknoG());
                }
                else
                {

                    try
                    {
                        bool update_available = false;
                        WebClient wb = new WebClient();
                        wb.DownloadFile(AnimePlayer.Properties.Settings.Default.UpdateLink_Version, "ver-lib.txt");
                        FileStream fss = new FileStream("ver-lib.txt", FileMode.Open, FileAccess.Read);
                        StreamReader swk = new StreamReader(fss);
                        string[] version_txt = File.ReadAllText("ver-lib.txt").Split('.');
                        swk.Close();
                        string[] currentVersion = Application.ProductVersion.Split('.');

                        if (int.Parse(version_txt[0]) > int.Parse(currentVersion[0]))// 1
                        {
                            update_available = true;
                        }
                        else if (int.Parse(version_txt[0]) <= int.Parse(currentVersion[0])) //1
                        {
                            if (int.Parse(version_txt[1]) > int.Parse(currentVersion[1])) //2
                            {
                                update_available = true;
                            }
                            else if (int.Parse(version_txt[1]) <= int.Parse(currentVersion[1])) //2
                            {
                                if (int.Parse(version_txt[2]) > int.Parse(currentVersion[2]))//3
                                {
                                    update_available = true;
                                }
                                else if (int.Parse(version_txt[2]) <= int.Parse(currentVersion[2])) // 3
                                {
                                    if (int.Parse(version_txt[3]) > int.Parse(currentVersion[3]))//4 
                                    {
                                        update_available = true;
                                    }
                                    else
                                    {
                                        update_available = false;
                                    }
                                }
                            }
                        }

                        if (update_available == true)
                        {
                            wb = new WebClient();
                            wb.DownloadFile(AnimePlayer.Properties.Settings.Default.UpdateLink_File, "lib_link_download.txt");
                            string[] zm = File.ReadAllText("lib_link_download.txt").Split(';');
                            wb = new WebClient();
                            wb.DownloadFile(zm[0], zm[0]);
                        }
                        File.Delete("ver-lib.txt");
                        File.Delete("lib_link_download.txt");
                    }
                    catch (Exception ex2)
                    {
                        File.Delete("ver-lib.txt");
                        File.Delete("lib_link_download.txt");
                        Console.WriteLine(ex2.ToString());
                        Environment.Exit(0);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił krytyczny błąd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("CrashApplogs.txt", ex.ToString() + Environment.NewLine);
            }
        }
    }
}
