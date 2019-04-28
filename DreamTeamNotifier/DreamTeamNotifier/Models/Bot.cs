using DreamTeamNotifier.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace DreamTeamNotifier.Models
{
    /// <summary>
    /// Singleton class that provide work with bot
    /// </summary>
    public class Bot
    {
        private static TelegramBotClient _bot;

        public static List<Command> Commands { get; private set; }

        private Bot()
        {
            CommandInitializer();
        }

        private void CommandInitializer()
        {
            Commands = new List<Command>
            {
                new StartCommand()
            };
        }

        public static async Task<TelegramBotClient> GetBot()
        {
            if (_bot == null)
            {
                _bot = new TelegramBotClient(AppSettings.Key);
                var webHookRoute = string.Concat(AppSettings.Url, "api/message/update");
                await _bot.SetWebhookAsync(webHookRoute);
            }
            return _bot;
        }
    }
}
