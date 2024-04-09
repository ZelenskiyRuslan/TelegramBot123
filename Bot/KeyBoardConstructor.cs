using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot
{
    public class KeyBoardConstructor
    {
        public ReplyKeyboardMarkup GetMainMenuKeyboard()
        {
            return new ReplyKeyboardMarkup(new[]
            {
            new KeyboardButton[] { "Брюки" },
            new KeyboardButton[] { "Худи" },
            new KeyboardButton[] { "Кроссовки" },
            new KeyboardButton[] { "Контактные данные" },
            new KeyboardButton[] { "Адреса" }
        });
        }

        public ReplyKeyboardMarkup GetSubMenuKeyboard(string mainMenuOption)
        {
            switch (mainMenuOption)
            {
                case "Брюки":
                    return new ReplyKeyboardMarkup(new[]
                    {
                    new KeyboardButton[] { "Брюки - BlackFord" },
                    new KeyboardButton[] { "Брюки - GJ" },
                    new KeyboardButton[] { "Брюки - Gear" },
                    new KeyboardButton[] { "Назад" }

                });
                case "Худи":
                    return new ReplyKeyboardMarkup(new[]
                    {
                    new KeyboardButton[] { "Худи - Calvin Klein" },
                    new KeyboardButton[] { "Худи - Various Colors" },
                    new KeyboardButton[] { "Худи - SUPREME" },
                    new KeyboardButton[] { "Назад" }
                });
                case "Кроссовки":
                    return new ReplyKeyboardMarkup(new[]
                    {
                    new KeyboardButton[] { "Кроссовки - Nike" },
                    new KeyboardButton[] { "Кроссовки - Adidas" },
                    new KeyboardButton[] { "Кроссовки - Reebok" },
                    new KeyboardButton[] { "Назад" }
                });
                default:
                    return new ReplyKeyboardMarkup(new[]
                    {
                    new KeyboardButton[] { "Назад" }
                });
            }
        }
    }
}
