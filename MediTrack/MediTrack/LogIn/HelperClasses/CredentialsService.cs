using System;
using System.Drawing;
using MediTrack.Properties;

namespace MediTrack
{
    public class CredentialsService
    {
        public bool IsRememberEnabled => Settings.Default.RememberUserComp;

        public (string username, string company) LoadSavedCredentials()
        {
            if (!IsRememberEnabled)
                return (null, null);

            return (
                username: Settings.Default.SavedUsername,
                company: Settings.Default.SavedCompany
            );
        }

        public void SaveCredentials(string username, string company)
        {
            if (!string.IsNullOrEmpty(username))
                Settings.Default.SavedUsername = username;

            if (!string.IsNullOrEmpty(company))
                Settings.Default.SavedCompany = company;

            Settings.Default.RememberUserComp = true;
            Settings.Default.Save();
        }

        public void ClearCredentials()
        {
            Settings.Default.SavedUsername = string.Empty;
            Settings.Default.SavedCompany = string.Empty;
            Settings.Default.RememberUserComp = false;
            Settings.Default.Save();
        }

        public void UpdateRememberSetting(bool remember)
        {
            Settings.Default.RememberUserComp = remember;
            Settings.Default.Save();
        }
    }
}