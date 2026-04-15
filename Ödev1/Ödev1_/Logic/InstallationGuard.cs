using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ödev1_.Logic
{
    public static class InstallationGuard
    {
        private const string RegPath = @"Software\HazineAvcisiGame";
        private const string InstallKey = "IsInstalled";
        private const string ProgressKey = "UserProgress";

        // Tekil Kurulum Kontrolü
        public static bool CanInstall()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegPath))
            {
                return key == null || key.GetValue(InstallKey) == null;
            }
        }

        public static void MarkAsInstalled()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegPath))
            {
                key.SetValue(InstallKey, "true");
            }
        }

        // Kalıcı Seviye İlerlemesi Okuma
        public static int GetSavedLevel()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegPath))
            {
                if (key != null && key.GetValue(ProgressKey) != null)
                {
                    return (int)key.GetValue(ProgressKey);
                }
                return 1; // Kayıt yoksa 1. seviye
            }
        }

        // Seviyeyi Kaydetme
        public static void SaveProgress(int level)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegPath))
            {
                int currentSaved = GetSavedLevel();
                if (level > currentSaved)
                {
                    key.SetValue(ProgressKey, level);
                }
            }
        }
    }
}
