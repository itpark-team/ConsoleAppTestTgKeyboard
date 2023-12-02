using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleAppTestTgKeyboard.Bot;

public class ReplyKeyboardsMarkupStorage
{
    public static IReplyMarkup Main = new ReplyKeyboardMarkup(new[]
    {
        new[]
        {
            new KeyboardButton("Кнопка 11"),
            new KeyboardButton("Кнопка 12")
        },
        new[]
        {
            new KeyboardButton("Кнопка 21"),
            new KeyboardButton("Кнопка 22")
        },
        new[]
        {
            new KeyboardButton("Кнопка 3")
        }
    });

    public static IReplyMarkup Hide = new ReplyKeyboardRemove();
}