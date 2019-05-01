using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenWeatherMap;
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

            var weatherMapClient = new OpenWeatherMapClient();
            // forecast - має варіант count, де є кількість днів
            // current - ну логічно)
            var forecast = await weatherMapClient.CurrentWeather.GetByCoordinates(new Coordinates
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude
            });
            
            
            var chatId = message.Chat.Id;
            var replyMessage = "";
            await client.SendTextMessageAsync(chatId, replyMessage, ParseMode.Html);
        }
    }
}
