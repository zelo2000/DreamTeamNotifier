using System.Threading.Tasks;
using System.Diagnostics;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using DTN.Core.Utility;
using System;

namespace DTN.Core.Commands.Weather
{
    /// <summary>
    /// Get location command
    /// </summary>
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

            dynamic forecast = new WeatherRepository().GetWeather(location.Latitude, location.Longitude);

            var replyMessage = $"Whether in the <b>{forecast.name}</b>\n\n" +
                $"temperature - <i>{forecast.main.temp} Kelvin degrees</i>\n" +
                $"clouds - <i>{forecast.clouds.all} %</i>\n" +
                $"humidity - <i>{forecast.main.humidity} %</i>\n" +
                $"wind - <i>{forecast.wind.speed} m/s</i>\n" +
                $"pressure - <i>{forecast.main.pressure} hPa</i>\n";

            Debug.WriteLine(replyMessage);

            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, replyMessage, ParseMode.Html);
        }
    }
}
