using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DTN.Core.Commands
{
    /// <summary>
    /// Abstract command 
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Command name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Execute a command
        /// </summary>
        /// <param name="message">Input message</param>
        /// <param name="client">Current bot</param>
        /// <returns></returns>
        public abstract Task Execute(Message message, TelegramBotClient client);

        /// <summary>
        /// Check whether it is command which we need
        /// </summary>
        /// <param name="message">Input message</param>
        /// <returns>True, if the message contains this command and false in the otherwise</returns>
        public abstract bool Contains(Message message);
    }
}