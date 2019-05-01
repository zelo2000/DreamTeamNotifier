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
        public static string Url { get; } = "https://81284863.ngrok.io"; //"https://dtntelegramapi20190430110017.azurewebsites.net/";
        public static string Name { get; set; } = "dream_team_notifier_bot";
        public static string Key { get; } = "801997150:AAFtMmPYZ_sYkpsADk09Gq7VD4KX6NVMi0o";
    }
}
