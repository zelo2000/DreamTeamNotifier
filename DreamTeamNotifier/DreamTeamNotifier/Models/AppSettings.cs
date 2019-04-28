using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamTeamNotifier.Models
{
    /// <summary>
    /// Bot main values (It's must be in appsettings)
    /// </summary>
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://dreamteamnotifier.azurewebsites.net";
        public static string Name { get; set; } = "dream_team_notifier_bot";
        public static string Key { get; set; } = "801997150:AAFtMmPYZ_sYkpsADk09Gq7VD4KX6NVMi0o";
    }
}
