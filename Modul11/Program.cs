using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Modul11.Controllers;
using Modul11.Services;
using Modul11.Configuration;

namespace Modul11
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            // Подключаем контроллеры сообщений и кнопок
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();
            services.AddSingleton<IStorage, MemoryStorage>();
            services.AddSingleton<IFileHandler, AudioFileHandler>();

            // Регистрируем объект TelegramBotClient c токеном подключения
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
            services.AddHostedService<Bot>();

            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                //                BotToken = "1735772714:AAG4TLlag_RexSaDZSv5SyznT3to3RajQ1w"
                DownloadsFolder = "C:\\Users\\evmor\\Downloads",
                BotToken = "1735772714:AAG4TLlag_RexSaDZSv5SyznT3to3RajQ1w",
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
            };
        }
    }
}
