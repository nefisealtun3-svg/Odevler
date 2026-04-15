using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ödev1_.Logic;

namespace Ödev1_
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!InstallationGuard.CanInstall())
            {
                MessageBox.Show("Bu yazılım bu bilgisayarda zaten bir kez çalıştırıldı/kuruldu. " +
                                "Tekrar kurulum yapamazsınız.", "Erişim Engellendi",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // İlk kez açılıyorsa iz bırak
            InstallationGuard.MarkAsInstalled();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LevelMenu());
        }
    }
}
