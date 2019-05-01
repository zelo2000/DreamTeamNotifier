using DTN.Core.Commands;
using DTN.Core.Commands.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace DTN.TelegramAPI.Models
{
    /// <summary>
    /// A class that provides an instance for working with telegram bot
    /// </summary>
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        private Bot() { }

        /// <summary>
        ///  Telegram bot сommands initialization
        /// </summary>
        private static void InitializeCommands()
        {
            commandsList = new List<Command>
            {
                new StartCommand(),
                new GetWeatherCommand(),
                new GetLocationCommand()
                //TODO: Add more commands
            };

        }

        /// <summary>
        ///  Get telegram bot instance
        /// </summary>
        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient == null)
            {
                InitializeCommands();

                botClient = new TelegramBotClient(AppSettings.Key);
                string hook = string.Concat(AppSettings.Url, "/message/update");
                await botClient.SetWebhookAsync(hook);
            }
            return botClient;
        }
    }
}
