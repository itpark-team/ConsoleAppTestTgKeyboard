using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleAppTestTgKeyboard.Bot;

public class InlineKeyboardsMarkupStorage
{
    public static IReplyMarkup Main = new InlineKeyboardMarkup(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData("Кнопка 11",
                "Кнопка 11"),
            InlineKeyboardButton.WithCallbackData("Кнопка 22", "Кнопка 2")
        }
    });
}