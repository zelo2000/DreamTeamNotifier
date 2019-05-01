using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DTN.Core.Commands.Weather
{
    public class GetLocationCommand : Command
    {
        public override string Name => @"/set_location";

        public override bool Contains(Message message)
        {
            return message.Type == MessageType.Location;
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var location = message.Location;
            //TODO get weather
            var chatId = message.Chat.Id;
            var replyMessage = "";
            await client.SendTextMessageAsync(chatId, replyMessage);
        }
    }
}
