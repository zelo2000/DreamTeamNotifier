using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DTN.TelegramAPI.Models
{
    /// <summary>
    /// Telegram bot settings (must be in config)
    /// </summary>
    public static class AppSettings
    {
        internal static string Url { get; } = "https://dtntelegramapi20190430110017.azurewebsites.net/";
        internal static string Name { get; } = "dream_team_notifier_bot";
        internal static string Key { get; } = "801997150:AAFtMmPYZ_sYkpsADk09Gq7VD4KX6NVMi0o";
    }
}
