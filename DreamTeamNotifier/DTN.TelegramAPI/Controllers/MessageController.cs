using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using DTN.TelegramAPI.Models;

namespace DTN.TelegramAPI.Controllers
{
    [Route("/message/update")]
    public class MessageController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Method GET unavailable";
        }

        // POST api/values
        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update != null)
            {
                var commands = Bot.Commands;
                var message = update.Message;
                var botClient = await Bot.GetBotClientAsync();
                bool checker = false;
                foreach (var command in commands)
                {
                    if (command.Contains(message))
                    {
                        await command.Execute(message, botClient);
                        checker = true;
                        break;
                    }
                }
                if (!checker)
                {
                    var chatId = message.Chat.Id;
                    await botClient.SendTextMessageAsync(chatId, "Wrong input.");
                }
            }
            return Ok();
        }
    }
}