using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DreamTeamNotifier.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "start";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Hello, world!", replyToMessageId: messageId);
        }
    }
}
