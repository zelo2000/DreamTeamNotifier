using DTN.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DTN.Core.Commands
{
    public class AddEventCommand : Command
    {
        public override string Name => @"\add_event_description";

        public override bool Contains(Message message)
        {
            if (message.Text.Contains("Event name"))
            {
                return false;
            }
            else
            {
                try
                {
                    var messageText = message.Text.Split(';');
                    var date_time = Convert.ToDateTime(messageText[0] + " " + messageText[1]);
                    var newEvent = new Event(messageText[2], date_time);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var messageText = message.Text.Split(';');
            var date_time = Convert.ToDateTime(messageText[0] + " " + messageText[1]);
            var newEvent = new Event(messageText[2], date_time);

            //TODO 

            var response = "Event successfully added!";
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, response);
        }
    }
}
