using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Modul11
{
    class Bot
    {
        /// <summary>
        /// объект, отвеающий за отправку сообщений клиенту
        /// </summary>
        private ITelegramBotClient _telegramClient;

        public Bot(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _telegramClient.OnMessage += HandleMessage;
            _telegramClient.OnMessage += HandleButtonClick;

            Console.WriteLine("Bot started");
        }

        /// <summary>
        /// Обработчик входящих текстовых сообщений  
        /// </summary>
        private async Task HandleMessage(object sender, MessageEventArgs e)
        {
            // Бот получил входящее сообщение пользователя
            var messageText = e.Message.Text;

            // Бот Отправляет ответ
            _telegramClient.SendTextMessage(e.ChatId, "Ответ на сообщение пользователя");
        }

        /// <summary>
        /// Обработчик нажатий на кнопки
        /// </summary>
        private async Task HandleButtonClick(object sender, MessageEventArgs e)
        {
        }
    }
}
