using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Modul11.Configuration;

namespace Modul11.Controllers
{
    class VoiceMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        //private readonly Configuration.AppSettings _appSettings;

        //public VoiceMessageController(ITelegramBotClient telegramBotClient, AppSettings appSettings)
        public VoiceMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено голосовое сообщение", cancellationToken: ct);
        }
    }
}
