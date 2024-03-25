using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

class Program
{
    static void Main(string[] args)
    {
        var client = new TelegramBotClient("7183919824:AAEMGRcHGwUK6nA2oZ5YPIRDdqcHnOtUN4s");
        //client.SendTextMessageAsync
        client.StartReceiving(Update, Error);
        Console.ReadLine();
    }

    private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }

    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken arg3)
    {
        var mes = update.Message;
        if (mes.Text != null)
        {
            if (mes.Text.ToLower().Contains("/start"))
            {
                await botClient.SendTextMessageAsync(mes.Chat.Id, "Привет, " + mes.From.FirstName + "! Я бот для продажи табачных изделий." + "Чтобы посмотреть товар можете использовать кнопки.");
                //await botClient.SendTextMessageAsync(mes.Chat.Id, "Также для продолжения работы со мной введите свой возраст.");
                Console.WriteLine("мне написали: " + mes.Text);
                return;
            }
        }
        if (mes.Photo != null)
        {
            await botClient.SendTextMessageAsync(mes.Chat.Id, "мне пришло фото");
            Console.WriteLine("Я не умею распозновать вид табачного изделия по фотографии.");
            return;
        }
        if (mes.Document != null)
        {
            await botClient.SendTextMessageAsync(mes.Chat.Id, "Не используйте меня как хранилище документов");
            Console.WriteLine("Мне пришёл документ");
            return; 
        }

            Console.WriteLine("Пришло неопознанное сообщение!!! " + mes.Text + " от пользователя: " + mes.From.FirstName);
    }

}
