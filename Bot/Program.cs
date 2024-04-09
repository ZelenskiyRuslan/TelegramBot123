using Bot;
using Bot.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    static void Main(string[] args)
    {
        var client = new TelegramBotClient("7183919824:AAEMGRcHGwUK6nA2oZ5YPIRDdqcHnOtUN4s");
        client.StartReceiving(UpdateHandler, Error);
        Console.ReadLine();
    }

    private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }

    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message == null)
        {
            return;
        }
        KeyBoardConstructor kbconst = new KeyBoardConstructor();
        var mes = update.Message;
        var chat = mes.Chat;
        if (mes.Text != null)
        {
            if (mes.Text.ToLower().Contains("/start"))
            {
                await botClient.SendTextMessageAsync(mes.Chat.Id, "Привет, " + mes.From.FirstName + "!\n Я бот для проверки ассортимента брендового магазина одежды 123.");
                await botClient.SendTextMessageAsync(mes.Chat.Id, "Выберите категорию:", replyMarkup: kbconst.GetMainMenuKeyboard());
                Console.WriteLine("мне написали: " + mes.Text);
                return;
            }
        }


        switch (mes.Text)
        {
            case "Брюки":
                await botClient.SendTextMessageAsync(mes.Chat.Id, "Вот вам ассортимент Брюк", replyMarkup: kbconst.GetSubMenuKeyboard("Брюки"));
                break;
            case "Худи":
                await botClient.SendTextMessageAsync(mes.Chat.Id, "Вот вам ассортимент Худи", replyMarkup: kbconst.GetSubMenuKeyboard("Худи"));
                break;
            case "Кроссовки":
                await botClient.SendTextMessageAsync(mes.Chat.Id, "Вот вам ассортимент Кроссовок", replyMarkup: kbconst.GetSubMenuKeyboard("Кроссовки"));
                break;
            case "Контактные данные":
                await botClient.SendTextMessageAsync(mes.Chat.Id, "Телефон: +7 800 555 35 35 \n Почта: zr54546r@mail.ru", replyMarkup: kbconst.GetSubMenuKeyboard("Контактные данные"));
                break;
            case "Адреса":
                await botClient.SendTextMessageAsync(mes.Chat.Id, "Вот вам адреса брендового магазина одежды 123.", replyMarkup: kbconst.GetSubMenuKeyboard("Адреса"));
                break;
            default:
                if (mes.Text == "Назад")
                    await botClient.SendTextMessageAsync(mes.Chat.Id, "Вы вернулись назад", replyMarkup: kbconst.GetMainMenuKeyboard());
                //else
                //    await botClient.SendTextMessageAsync(mes.Chat.Id, "Неопознанное сообщение. Пожалуйста, используйте кнопки для взаимодействия.", replyMarkup: GetMainMenuKeyboard());
                //Console.WriteLine("Пришло неопознанное сообщение!!! " + mes.Text + " от пользователя: " + mes.From.FirstName);
                break;
        }
    
        switch (mes.Type)
        {
            case MessageType.Text:
                {
                    if (mes.Text == null)
                    {
                        return;

                    }

                    if (mes.Text == "Адреса")
                    {
                        //создание кнопок в строке
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Москва", callbackData: "Москва"),
                                            InlineKeyboardButton.WithCallbackData(text: "Санкт-Петербург", callbackData: "Санкт-Петербург"),
                                        }
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Выберете город:",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Брюки - BlackFord")
                    {
                        //создание кнопок в строке
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "BlackFord Чёрные", callbackData: "BlackFord Чёрные"),
                                            InlineKeyboardButton.WithCallbackData(text: "BlackFord Серые", callbackData: "BlackFord Серые"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "BlackFord Хаки", callbackData: "BlackFord Хаки"),
                                        },
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Брюки модели BlackFord",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Брюки - GJ")
                    {
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "GJ Чёрные", callbackData: "GJ Чёрные"),
                                            InlineKeyboardButton.WithCallbackData(text: "GJ белые", callbackData: "GJ белые"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "GJ 'хаки2'", callbackData: "GJ 'хаки2'"),
                                        },
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Брюки модели GJ",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Брюки - Gear")
                    {
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Gear Камуфляж Зелёный", callbackData: "Gear Камуфляж Зелёный"),
                                            InlineKeyboardButton.WithCallbackData(text: "Gear Камуфляж Синий", callbackData: "Gear Камуфляж Синий"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Gear Камуфляж Чёрный", callbackData: "Gear Камуфляж Чёрный"),
                                        },
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Брюки модели Gear",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Худи - Calvin Klein")
                    {
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                            //создание кнопок в строке
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Calvin Klein С надписью Тёмное", callbackData: "Calvin Klein С надписью Тёмное"),
                                            InlineKeyboardButton.WithCallbackData(text: "Calvin Klein С надписью Синее", callbackData: "Calvin Klein С надписью Синее"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Calvin Klein Без надписи Белое", callbackData: "Calvin Klein Без надписи Белое"),
                                        },
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Худи модели Calvin Klein",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Худи - Various Colors")
                    {
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Various Colors Цвет на ваш выбор", callbackData: "Various Colors Цвет на ваш выбор"),
                                            InlineKeyboardButton.WithCallbackData(text: "Various Colors Цвет на ваш выбор + надпись", callbackData: "Various Colors Цвет на ваш выбор + надпись"),
                                        }
                                       
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Худи модели Various Colors",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Худи - SUPREME")
                    {
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "SUPREME Чёрное", callbackData: "SUPREME Чёрное"),
                                            InlineKeyboardButton.WithCallbackData(text: "SUPREME Серое", callbackData: "SUPREME Серое"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "SUPREME Хаки", callbackData: "SUPREME Хаки"),
                                        },
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Худи модели SUPREME",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Кроссовки - Nike")
                    {
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                            //создание кнопок в строке
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Nike Air", callbackData: "Nike Air"),
                                            InlineKeyboardButton.WithCallbackData(text: "Nike Jordan", callbackData: "Nike Jordan"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Nike Dunk", callbackData: "Nike Dunk"),
                                        },
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Кроссовки модели Nike",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Кроссовки - Adidas")
                    {
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Adidas 3 полоски", callbackData: "Adidas 3 полоски"),
                                            InlineKeyboardButton.WithCallbackData(text: "Adidas 3,5 полоски", callbackData: "Adidas 3,5 полоски"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Adidas Abibas(4 полоски)", callbackData: "Adidas Abibas(4 полоски)"),
                                        },
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Кроссовки модели Adidas",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }

                    if (mes.Text == "Кроссовки - Reebok")
                    {
                        InlineKeyboardMarkup inlineKeyboard = new(new[]
                        {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Reebok Чёрные", callbackData: "Reebok Чёрные"),
                                            InlineKeyboardButton.WithCallbackData(text: "Reebok Серые", callbackData: "Reebok Серые"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Reebok Белые", callbackData: "Reebok Белые"),
                                        },
                                        });

                        Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chat.Id,
                            text: "Кроссовки модели Reebok",
                            replyMarkup: inlineKeyboard,
                            cancellationToken: cancellationToken);

                        return;
                    }
                    return;
                }
        }

        if (mes.Photo != null)
        {
            await botClient.SendTextMessageAsync(mes.Chat.Id, "мне пришло фото", replyMarkup: kbconst.GetMainMenuKeyboard());
            Console.WriteLine("Я не умею распознавать вид одежды по фотографии.");
        }

        if (mes.Document != null)
        {
            await botClient.SendTextMessageAsync(mes.Chat.Id, "Не используйте меня как хранилище документов", replyMarkup: kbconst.GetMainMenuKeyboard());
            Console.WriteLine("Мне пришёл документ");
        }
    }

    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await CallBack(botClient, update, cancellationToken);
        await Update(botClient, update, cancellationToken);
    }
    private static async Task CallBack(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        //вывод в зависимости от выбранной кнопки
        if (update != null && update.CallbackQuery != null)
        {
            string answer = update.CallbackQuery.Data;
            TelegramBotContext context = new TelegramBotContext();
            switch (answer)
            {
                case "Москва":
                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Адресы в Москве: \n Новый Арбат ул., 89 \n Хрущевский пер., 62");
                    break;
                case "Санкт-Петербург":
                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Адрес в Санкт-Петербурге: \n Ул. Марата, 75");
                    break;
                case "BlackFord Чёрные":
                    Close close = context.Closes.First(x => x.Id == 6);
                    
                    string adreses = "";
                    var list = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x=>x.Idcloses ==6))
                    {
                        Outlet outlet = list.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text = $"{close.Name}\nИнформация о данной модели: \n {adreses}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text);
                    break;
                case "BlackFord Серые":
                    Close close1 = context.Closes.First(x => x.Id == 4);

                    string adreses1 = "";
                    var list1 = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 4))
                    {
                        Outlet outlet = list1.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses1 += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text1 = $"{close1.Name}\nИнформация о данной модели: \n {adreses1}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text1);
                    break;
                case "BlackFord Хаки":
                    Close close2 = context.Closes.First(x => x.Id == 5);

                    string adreses2 = "";
                    var list2 = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 5))
                    {
                        Outlet outlet = list2.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses2 += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text2 = $"{close2.Name}\nИнформация о данной модели: \n {adreses2}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text2);
                    break;

                case "GJ Чёрные":
                    Close closeq = context.Closes.First(x => x.Id == 15);

                    string adresesq = "";
                    var listq = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 15))
                    {
                        Outlet outlet = listq.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesq += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textq = $"{closeq.Name}\nИнформация о данной модели: \n {adresesq}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textq);
                    break;
                case "GJ белые":
                    Close close3 = context.Closes.First(x => x.Id == 13);

                    string adreses3 = "";
                    var list3 = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 13))
                    {
                        Outlet outlet = list3.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses3 += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text3 = $"{close3.Name}\nИнформация о данной модели: \n {adreses3}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text3);
                    break;
                case "GJ 'хаки2'":
                    Close closev = context.Closes.First(x => x.Id == 14);

                    string adresesv = "";
                    var listv = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 14))
                    {
                        Outlet outlet = listv.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesv += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textv = $"{closev.Name}\nИнформация о данной модели: \n {adresesv}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textv);
                    break;

                case "Gear Камуфляж Зелёный":
                    Close close4 = context.Closes.First(x => x.Id == 10);

                    string adreses4 = "";
                    var list4 = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 10))
                    {
                        Outlet outlet = list4.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses4 += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text4 = $"{close4.Name}\nИнформация о данной модели: \n {adreses4}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text4);
                    break;
                case "Gear Камуфляж Синий":
                    Close closea = context.Closes.First(x => x.Id == 11);

                    string adresesa = "";
                    var lista = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 11))
                    {
                        Outlet outlet = lista.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesa += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string texta = $"{closea.Name}\nИнформация о данной модели: \n {adresesa}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, texta);
                    break;
                case "Gear Камуфляж Чёрный":
                    Close closee = context.Closes.First(x => x.Id == 12);

                    string adresese = "";
                    var liste = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 12))
                    {
                        Outlet outlet = liste.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresese += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string texte = $"{closee.Name}\nИнформация о данной модели: \n {adresese}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, texte);
                    break;

                case "Calvin Klein С надписью Тёмное":
                    Close closez = context.Closes.First(x => x.Id == 9);

                    string adresesz = "";
                    var listz = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 9))
                    {
                        Outlet outlet = listz.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesz += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textz = $"{closez.Name}\nИнформация о данной модели: \n {adresesz}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textz);
                    break;
                case "Calvin Klein С надписью Синее":
                    Close closex = context.Closes.First(x => x.Id == 8);

                    string adresesx = "";
                    var listx = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 8))
                    {
                        Outlet outlet = listx.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesx += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textx = $"{closex.Name}\nИнформация о данной модели: \n {adresesx}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textx);
                    break;
                case "Calvin Klein Без надписи Белое":
                    Close closec = context.Closes.First(x => x.Id == 7);

                    string adresesc = "";
                    var listc = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 7))
                    {
                        Outlet outlet = listc.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesc += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textc = $"{closec.Name}\nИнформация о данной модели: \n {adresesc}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textc);
                    break;

                case "Various Colors Цвет на ваш выбор":
                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Various Colors Цвет на ваш выбор\n"+"Информация о данной модели обговаривается напрямую с продовцом (данные для связи можно получить нажав на кнопку 'Контакты').");
                    break;
                case "Various Colors Цвет на ваш выбор + надпись":
                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Various Colors Цвет на ваш выбор + надпись\n"+"Информация о данной модели обговаривается напрямую с продовцом (данные для связи можно получить нажав на кнопку 'Контакты').");
                    break;

                case "SUPREME Чёрное":
                    Close closeb = context.Closes.First(x => x.Id == 24);

                    string adresesb = "";
                    var listb = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 24))
                    {
                        Outlet outlet = listb.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesb += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textb = $"{closeb.Name}\nИнформация о данной модели: \n {adresesb}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textb);
                    break;
                case "SUPREME Серое":
                    Close closen = context.Closes.First(x => x.Id == 22);

                    string adresesn = "";
                    var listn = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 22))
                    {
                        Outlet outlet = listn.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesn += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textn = $"{closen.Name}\nИнформация о данной модели: \n {adresesn}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textn);
                    break;
                case "SUPREME Хаки":
                    Close close6 = context.Closes.First(x => x.Id == 23);

                    string adreses6 = "";
                    var list6 = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 23))
                    {
                        Outlet outlet = list6.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses6 += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text6 = $"{close6.Name}\nИнформация о данной модели: \n {adreses6}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text6);
                    break;

                case "Nike Air":
                    Close close7 = context.Closes.First(x => x.Id == 16);

                    string adreses7 = "";
                    var list7 = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 16))
                    {
                        Outlet outlet = list7.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses7 += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text7 = $"{close7.Name}\nИнформация о данной модели: \n {adreses7}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text7);
                    break;
                case "Nike Jordan":
                    Close close8 = context.Closes.First(x => x.Id == 18);

                    string adreses8 = "";
                    var list8 = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 18))
                    {
                        Outlet outlet = list8.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses8 += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text8 = $"{close8.Name}\nИнформация о данной модели: \n {adreses8}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text8);
                    break;
                case "Nike Dunk":
                    Close close0 = context.Closes.First(x => x.Id == 17);

                    string adreses0 = "";
                    var list0 = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 17))
                    {
                        Outlet outlet = list0.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adreses0 += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string text0 = $"{close0.Name}\nИнформация о данной модели: \n {adreses0}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text0);
                    break;

                case "Adidas 3 полоски":
                    Close closer = context.Closes.First(x => x.Id == 1);

                    string adresesr = "";
                    var listr = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 1))
                    {
                        Outlet outlet = listr.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesr += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textr = $"{closer.Name}\nИнформация о данной модели: \n {adresesr}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textr);
                    break;
                case "Adidas 3,5 полоски":
                    Close closet = context.Closes.First(x => x.Id == 2);

                    string adresest = "";
                    var listt = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 2))
                    {
                        Outlet outlet = listt.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresest += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textt = $"{closet.Name}\nИнформация о данной модели: \n {adresest}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textt);
                    break;
                case "Adidas Abibas(4 полоски)":
                    Close closey = context.Closes.First(x => x.Id == 3);

                    string adresesy = "";
                    var listy = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 3))
                    {
                        Outlet outlet = listy.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesy += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string texty = $"{closey.Name}\nИнформация о данной модели: \n {adresesy}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, texty);
                    break;

                case "Reebok Чёрные":
                    Close closeu = context.Closes.First(x => x.Id == 21);

                    string adresesu = "";
                    var listu = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 21))
                    {
                        Outlet outlet = listu.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesu += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textu = $"{closeu.Name}\nИнформация о данной модели: \n {adresesu}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textu);
                    break;
                case "Reebok Серые":
                    Close closei = context.Closes.First(x => x.Id == 20);

                    string adresesi = "";
                    var listi = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 20))
                    {
                        Outlet outlet = listi.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesi += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string texti = $"{closei.Name}\nИнформация о данной модели: \n {adresesi}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, texti);
                    break;
                case "Reebok Белые":
                    Close closef = context.Closes.First(x => x.Id == 19);

                    string adresesf = "";
                    var listf = context.Outlets.ToList();
                    foreach (var item in context.CousesOnOutLets.Where(x => x.Idcloses == 19))
                    {
                        Outlet outlet = listf.FirstOrDefault(x => x.Id == item.Idoutlets);
                        adresesf += $"\t По адрессу: {item.IdoutletsNavigation.Adress}\t Количество:{item.Count}\t  Размеры: {item.Size}\n\n";
                    }
                    string textf = $"{closef.Name}\nИнформация о данной модели: \n {adresesf}";

                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, textf);
                    break;
            }
        }
    }
}
