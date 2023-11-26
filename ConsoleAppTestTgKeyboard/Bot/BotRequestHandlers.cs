
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleAppTestTgKeyboard.Bot;

public class BotRequestHandlers
{

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        long chatId = 0;
        int messageFromUserId = 0;
        string textData = "";
        bool canRoute = false;

        try
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    if (update.Message != null)
                    {
                        canRoute = true;
                        chatId = update.Message.Chat.Id;
                        messageFromUserId = update.Message.MessageId;
                        textData = update.Message.Text;
                    }

                    break;

                case UpdateType.CallbackQuery:
                    if (update.CallbackQuery != null)
                    {
                        canRoute = true;
                        chatId = update.CallbackQuery.Message.Chat.Id;
                        messageFromUserId = update.CallbackQuery.Message.MessageId;
                        textData = update.CallbackQuery.Data;
                    }

                    break;
            }

            if (canRoute)
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "TEST TEXT",
                    replyMarkup: null,
                    cancellationToken: cancellationToken);
            }
        }
        catch (Exception e)
        {
            await botClient.DeleteMessageAsync(
                chatId: chatId,
                messageId: messageFromUserId,
                cancellationToken: cancellationToken
            );
        }
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };
        
        return Task.CompletedTask;
    }
}