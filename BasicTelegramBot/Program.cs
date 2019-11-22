using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BasicTelegramBot
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("1069436916:AAEnOYARR7BDVedBj9j7o6-MSh0KVwZmCqI");
        static void Main(string[] args)
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                Console.WriteLine(e.Message.Text);
                if (e.Message.Text == "Erich Cuzao") Bot.SendTextMessageAsync(e.Message.Chat.Id, "Muito mesmo" + e.Message.Chat.Username + ". .  ");
                else
                {
                    if (e.Message.Text == "Rafael")
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, "Dev Mec do mec mec top");
                    else if (e.Message.Text == "Aninha") Bot.SendTextMessageAsync(e.Message.Chat.Id, "Desing Mec do mec mec top");
                }
            }
        }
    }
}
