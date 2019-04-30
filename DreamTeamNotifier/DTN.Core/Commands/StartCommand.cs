using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DTN.Core.Commands
{
    /// <summary>
    /// Start command which implement command
    /// </summary>
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, "Hello, I'm Dream Team notifier bot");
        }
    }
}
