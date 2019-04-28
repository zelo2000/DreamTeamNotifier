using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamTeamNotifier.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace DreamTeamNotifier.Controllers
{
    [Route("api/message/update")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public async Task<OkResult> Update([FromBody] Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.GetBot();

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}