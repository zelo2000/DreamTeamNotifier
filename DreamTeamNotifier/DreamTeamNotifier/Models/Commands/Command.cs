using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DreamTeamNotifier.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public virtual bool Contains(string command)
        {
            return command.Contains(Name) && command.Contains(AppSettings.Name);
        }
    }
}
